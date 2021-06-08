using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ServiceBouncer.ComponentModel
{
    public class SortableBindingList<T> : BindingList<T> where T : class
    {
        private bool isSorted;
        private ListSortDirection sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor sortProperty;
        
        public SortableBindingList(IList<T> list)
            : base(list)
        {
        }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => isSorted;
        protected override ListSortDirection SortDirectionCore => sortDirection;
        protected override PropertyDescriptor SortPropertyCore => sortProperty;

        protected override void RemoveSortCore()
        {
            sortDirection = ListSortDirection.Ascending;
            sortProperty = null;
            isSorted = false;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            sortProperty = prop;
            sortDirection = direction;

            if (!(Items is List<T> list))
            {
                return;
            }

            list.Sort(Compare);

            isSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(T x, T y)
        {
            var result = OnComparison(x, y);
            if (sortDirection == ListSortDirection.Descending)
            {
                result = -result;
            }

            return result;
        }

        private int OnComparison(T x, T y)
        {
            var xValue = x == null ? null : sortProperty.GetValue(x);
            var yValue = y == null ? null : sortProperty.GetValue(y);

            if (xValue == null)
            {
                return (yValue == null) ? 0 : -1;
            }

            if (yValue == null)
            {
                return 1;
            }

            if (xValue is IComparable value)
            {
                return value.CompareTo(yValue);
            }

            if (xValue.Equals(yValue))
            {
                return 0;
            }

            return string.Compare(xValue.ToString(), yValue.ToString(), StringComparison.Ordinal);
        }
    }
}
