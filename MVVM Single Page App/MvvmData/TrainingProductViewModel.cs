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
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            EventCommand = "List";
        }

        public List<TrainingProduct> Products{ get; set; }
        public string EventCommand { get; set; }
        public TrainingProduct SearchEntity { get; set; }
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
                default:
                    break;
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
    }
}
