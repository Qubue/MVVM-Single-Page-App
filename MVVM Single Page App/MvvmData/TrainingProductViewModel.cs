using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmData
{
    public class TrainingProductViewModel
    {
        public TrainingProductViewModel()
        {
            ListMode();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
            EventCommand = "List";
            EventArgument = string.Empty;
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
        public List<TrainingProduct> Products{ get; set; }
        public string EventCommand { get; set; }
        public TrainingProduct SearchEntity { get; set; }
        public TrainingProduct Entity { get; set; }
        public bool isValid { get; set; }
        public string Mode { get; set; }

        public string EventArgument { get; set; }

        public bool isDetailAreaVisible { get; set; }
        public bool isListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }

        public void HandleRequest()
        {
            switch(EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetsearch":
                    Get();
                    break;
                case "add":
                    Add();
                    break;
                case "cancel":
                    ListMode();
                    Get();
                    break;
                case "save":
                    Save();
                    if(isValid)
                    {
                        Get();
                    }
                    break;
                case "edit":

                    break;
                default:
                    break;
            }
        }
        private void Save()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            if (Mode == "Add")
                {
                    mgr.Insert(Entity);
                }
            ValidationErrors = mgr.ValidationErrors;
            if(ValidationErrors.Count>0)
            {
                isValid = false;
            }
            if (!isValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
            }
        }

        private void ResetSearch()
        {
            SearchEntity = new TrainingProduct();
        }
        private void Get()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity);
        }
        
        private void ListMode()
        {
            isValid = true;

            isListAreaVisible = true;
            isSearchAreaVisible = true;
            isDetailAreaVisible = false;

            Mode = "List";
        }

        private void Add()
        {
            isValid = true;

            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "http://";
            Entity.Price = 0;

            AddMode();
        }

        private void AddMode()
        {
            isListAreaVisible = false;
            isSearchAreaVisible = false;
            isDetailAreaVisible = true;

            Mode = "Add";
        }
    }
}
