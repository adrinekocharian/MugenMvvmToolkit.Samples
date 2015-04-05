using System.Windows.Input;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ApiExamples.ViewModels.Tabs
{
    public class TabViewModel : MultiViewModel
    {
        #region Constructors

        public TabViewModel()
        {
            AddCommand = new RelayCommand(Add);
            InsertCommand = new RelayCommand(Insert, CanInsert, this);
            RemoveCommand = new RelayCommand(Remove, CanRemove, this);
        }

        #endregion

        #region Commands

        public ICommand AddCommand { get; private set; }

        public ICommand InsertCommand { get; private set; }

        public ICommand RemoveCommand { get; private set; }

        private void Add()
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic item";
            AddViewModel(itemViewModel);
            SelectedItem = itemViewModel;
        }

        private bool CanRemove()
        {
            return SelectedItem != null;
        }

        private void Remove()
        {
            RemoveViewModelAsync(SelectedItem);
        }

        private bool CanInsert()
        {
            return SelectedItem != null;
        }

        private void Insert()
        {
            var itemViewModel = GetViewModel<ItemViewModel>();
            itemViewModel.Name = "Dynamic item";
            int selectedIndex = ItemsSource.IndexOf(SelectedItem);
            ItemsSource.Insert(selectedIndex, itemViewModel);
            SelectedItem = itemViewModel;
        }

        #endregion
    }
}