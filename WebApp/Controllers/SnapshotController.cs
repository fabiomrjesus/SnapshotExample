using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SnapshotController : Controller
    {

        public SnapshotController()
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TakeSnapshot([FromForm] SnapshotRequestViewModel request)
        {
            StartSnapshot(request);
            return View(request);
        }

        private void StartSnapshot(SnapshotRequestViewModel request)
        {

        }

        public SnapshotResultViewModel GetResult()
        {
            return new SnapshotResultViewModel
            {
                Id = "snapshot1",
                Blocks = {
                    new ProcessedBlock(){Number =1, TransactionsFound = 0, RelatedAddresses = new()},
                    new ProcessedBlock(){Number =2, TransactionsFound = 4, RelatedAddresses = new(){"a", "b", "c"}},
                    new ProcessedBlock(){Number =3, TransactionsFound = 2, RelatedAddresses = new(){"a", "b" }}
                }
            };
        }

        public List<TokenHolderViewModel> GetTokenHolders()
        {
            return new List<TokenHolderViewModel>()
            {
                new TokenHolderViewModel(){Address ="A", Amount=500},
                new TokenHolderViewModel(){Address ="B", Amount=100},
                new TokenHolderViewModel(){Address ="C", Amount=2500},
                new TokenHolderViewModel(){Address ="D", Amount=1500},
            };
        }

        public TokenTradesViewModel GetTokenTransfers()
        {
            return new TokenTradesViewModel()
            {
                TransferNodes = new() { 
                    new() { Id = 1, Name = "A" },
                    new() { Id = 2, Name = "B" },
                    new() { Id = 3, Name = "C" }, 
                    new() { Id = 4, Name = "D" },
                    new() { Id = 5, Name = "E" }
                },
                Transfers = new()
                {
                    new Transfer() { Source = 1, Target = 4, Amount = 500 },
                    new Transfer() { Source = 2, Target = 4, Amount = 100 },
                    new Transfer() { Source = 3, Target = 1, Amount = 2500 },
                    new Transfer() { Source = 4, Target = 3, Amount = 1500 },
                    new Transfer() { Source = 4, Target = 5, Amount = 5500 }
                }
            };
        }

        public bool IsSnapshotRunning()
        {
            return true;
        }

        public ContractBasicInfo CheckIfIsContractAndToken(string address)
        {
            return new ContractBasicInfo{ IsContract = true, IsToken= true};
        }
    }
}
