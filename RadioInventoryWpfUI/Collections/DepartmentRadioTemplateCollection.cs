using RadioInventoryWpfUI.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioInventoryWpfUI.Models
{
    public class DepartmentRadioTemplateCollection : ObservableCollection<DepartmentRadioTemplateWpfModel>
    {
        public int TotalRadiosToCreate => this.Sum(d => d.QuantityToCreate);

        public DepartmentRadioTemplateCollection()
        {
            CollectionChanged += (s, e) => OnPropertyChanged(new PropertyChangedEventArgs(nameof(TotalRadiosToCreate)));
        }

        public DepartmentRadioTemplateCollection(List<DepartmentRadioTemplateWpfModel> list) : base(list)
        {
            CollectionChanged += (s, e) => OnPropertyChanged(new PropertyChangedEventArgs(nameof(TotalRadiosToCreate)));

            foreach (var item in list)
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        protected override void InsertItem(int index, DepartmentRadioTemplateWpfModel item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            item.PropertyChanged += Item_PropertyChanged;
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            var item = this[index];
            item.PropertyChanged -= Item_PropertyChanged;
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
            base.ClearItems();
        }

        protected override void SetItem(int index, DepartmentRadioTemplateWpfModel item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var oldItem = this[index];
            oldItem.PropertyChanged -= Item_PropertyChanged;
            item.PropertyChanged += Item_PropertyChanged;
            base.SetItem(index, item);
        }

        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DepartmentRadioTemplateWpfModel.QuantityToCreate))
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(TotalRadiosToCreate)));
            }
        }
    }
}
