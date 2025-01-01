using RadioInventoryLibrary.DataAccess;
using RadioInventoryLibrary.Factories;
using RadioInventoryLibrary.Models;
using RadioInventoryWpfUI.Bases;
using RadioInventoryWpfUI.Commands;
using RadioInventoryWpfUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RadioInventoryWpfUI.ViewModels
{
    public class CreateRadiosViewModel : BindableBase
    {
        private readonly IDataAccess _dataAccess;
        private readonly IRadioFactory _radioFactory;

        public DepartmentRadioTemplateCollection DepartmentRadioTemplates { get; set; }

        private string _changeAllQuantitiesText = string.Empty;
        public string ChangeAllQuantitiesText
        {
            get => _changeAllQuantitiesText;
            set
            {
                _changeAllQuantitiesText = value;
                OnPropertyChanged(nameof(ChangeAllQuantitiesText));
            }
        }


        public ICommand CreateRadiosCommand { get; set; }
        public ICommand ChangeAllQuantitiesCommand { get; set; }


        public CreateRadiosViewModel(IDataAccess dataAccess, IDepartmentRadioTemplateFactory departmentRadioTemplateFactory, IRadioFactory radioFactory)
        {
            _dataAccess = dataAccess;
            _radioFactory = radioFactory;

            DepartmentRadioTemplates = new DepartmentRadioTemplateCollection(
                App
                .Mapper
                .Map<List<DepartmentRadioTemplateWpfModel>>(departmentRadioTemplateFactory.GetTemplatesForAllDepartments()));

            CreateRadiosCommand = new MyICommand<string?>(OnCreate);
            ChangeAllQuantitiesCommand = new MyICommand<string?>(OnChangeAllQuantities);
        }

        public void OnCreate(string? parameter = null)
        {
            bool creationApproved = MessageBox.Show("Are you sure you want to create these radios?",
                                                    "Create Radios?",
                                                    MessageBoxButton.YesNo,
                                                    MessageBoxImage.Question) == MessageBoxResult.Yes;

            if (creationApproved == true)
            {
                var departmentRadioTemplateModels = App.Mapper.Map<List<DepartmentRadioTemplateModel>>(DepartmentRadioTemplates.ToList());
                List<BasicRadioModel> radios = _radioFactory.CreateRadiosFromDepartmentTemplates(departmentRadioTemplateModels);

                if (radios.Any())
                {
                    _dataAccess.InsertBulkRadios(radios);

                    MessageBox.Show("Radios created!",
                        "Radios created!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);
                }
                else
                {
                    MessageBox.Show("There were no radios to create.",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }

        public void OnChangeAllQuantities(string? quantityString)
        {
            var isInt = int.TryParse(quantityString, out int quantity);

            if (isInt && quantity >= 0)
            {
                foreach (var template in DepartmentRadioTemplates)
                {
                    template.QuantityToCreate = quantity;
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter an integer that is 0 or higher.",
                                "Invalid Input",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}
