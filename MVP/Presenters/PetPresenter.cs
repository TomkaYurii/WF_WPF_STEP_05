using MVP.Models;
using MVP.Views;

namespace MVP.Presenters
{
    public class PetPresenter
    {
        //Fields
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petList;

        //Constructor
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            petsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            //Set pets bindind source
            this.view.SetPetListBindingSource(petsBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList;//Set data source.
        }
        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petsBindingSource.DataSource = petList;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void SavePet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddNewPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
