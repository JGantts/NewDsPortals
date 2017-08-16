using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.Gui.Common
{
    public static class BridgeBuilder
    {
        public delegate TUpper LowerToUpper<TLower, TUpper>(TLower lower);

        private static List<object> _Bridges = new List<object>();

        public static void BuildBridge<TLower, TUpper>
            (ObservableCollection<TLower> lower,
            ObservableCollection<TUpper> upper,
            LowerToUpper<TLower, TUpper> lowerToUpper)
        {
            Debug.Assert(lower != null);
            Debug.Assert(upper != null);

            _Bridges.Add(
                new ObservableCollectionBridge<TLower, TUpper>
                (lower, upper, lowerToUpper));
        }

        private class ObservableCollectionBridge<TLower, TUpper>
        {
            private object _Lock = new object();
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
                throw new NeworkGuiException();
            }
        }
    }
}
