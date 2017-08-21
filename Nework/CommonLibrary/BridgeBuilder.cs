using Nework.CommonLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;

namespace Nework.CommonLibrary
{
    public abstract class Bridge
    {
        internal abstract void BlowUp();
    }

    public static class BridgeBuilder
    {
        public delegate TUpper LowerToUpper<TLower, TUpper>(TLower lower);

        private static List<Bridge> m_Bridges = new List<Bridge>();

        public static void BuildBridge<TLower, TUpper>
            (ObservableCollection<TLower> lower,
            ObservableCollection<TUpper> upper,
            LowerToUpper<TLower, TUpper> lowerToUpper)
        {
            Bridge temp = null;
            BuildBridge(ref temp, lower, upper, lowerToUpper);
        }
        public static void BuildBridge<TLower, TUpper>
            (ref Bridge bridgeLocation,
            ObservableCollection<TLower> lower,
            ObservableCollection<TUpper> upper,
            LowerToUpper<TLower, TUpper> lowerToUpper)
        {
            Debug.Assert(lower != null);
            Debug.Assert(upper != null);

            lock (m_Bridges)
            {
                if (bridgeLocation != null)
                {
                    m_Bridges.Remove(bridgeLocation);
                    bridgeLocation.BlowUp();
                }
                bridgeLocation = new ObservableCollectionBridge<TLower, TUpper>
                    (lower, upper, lowerToUpper);
                m_Bridges.Add(bridgeLocation);
            }

        }

        private class ObservableCollectionBridge<TLower, TUpper> : Bridge
        {
            private object _Lock { get; } = new object();
            private ObservableCollection<TLower> _Lower { get; }
            private ObservableCollection<TUpper> _Upper { get; }
            private LowerToUpper<TLower, TUpper> _LowerToUpper { get; }

            public ObservableCollectionBridge
                (ObservableCollection<TLower> lower,
                ObservableCollection<TUpper> upper,
                LowerToUpper<TLower, TUpper> lowerToUpper)
            {
                _Lower = lower;
                _Upper = upper;
                _LowerToUpper = lowerToUpper;

                _Lower.CollectionChanged += Lower_CollectionChanged;
                _Upper.CollectionChanged += Upper_CollectionChanged;

                Lower_CollectionChanged(null, null);
            }

            internal override void BlowUp()
            {
                _Upper.CollectionChanged -= Upper_CollectionChanged;
                _Lower.CollectionChanged -= Lower_CollectionChanged;
            }

            private void Lower_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                lock (_Lock)
                {
                    _Upper.CollectionChanged -= Upper_CollectionChanged;
                    _Upper.Clear();

                    foreach (TLower lowerItem in _Lower)
                    {
                        _Upper.Add(_LowerToUpper(lowerItem));
                    }

                    _Upper.CollectionChanged += Upper_CollectionChanged;
                }
            }

            private void Upper_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                throw new CommonLibraryException();
            }
        }
    }
}
