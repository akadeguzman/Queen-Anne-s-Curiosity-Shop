using System.Linq;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class PurchasingAgentService
    {
        private QueenAnneCuriosityShopContext _context;

        public PurchasingAgentService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<PurchasingAgent> GetPurchasingAgents()
        {
            return _context.PurchasingAgents;
        }
    }
}