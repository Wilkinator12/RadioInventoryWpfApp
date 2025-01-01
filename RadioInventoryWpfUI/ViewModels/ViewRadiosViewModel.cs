using RadioInventoryLibrary.DataAccess;
using RadioInventoryLibrary.Factories;
using RadioInventoryLibrary.Models;
using RadioInventoryWpfUI.Bases;
using RadioInventoryWpfUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioInventoryWpfUI.ViewModels
{
    public class ViewRadiosViewModel : BindableBase
    {
        private readonly IDataAccess _data;


        public ObservableCollection<RadioWpfModel> DisplayRadios { get; set; } = new ObservableCollection<RadioWpfModel>();




        public ViewRadiosViewModel(IDataAccess data)
        {
            _data = data;
        }

        public void LoadRadios()
        {
            DisplayRadios.Clear();


            var radios = _data.GetAllFullRadios().OrderBy(r => r.InsideLabel);



            // This should be in a WPF Library
            foreach (var radio in radios)
            {
                var radioWpfModel =
                    App.Mapper
                    .Map<RadioWpfModel>(radio);

                DisplayRadios.Add(radioWpfModel);
            }
        }
    }
}
