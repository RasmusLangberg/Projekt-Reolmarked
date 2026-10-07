using Projekt_Reolmarked.Model;
using System.Linq;

namespace Projekt_Reolmarked.ViewModel
{
    public class MonthlySettlementViewModel : INotifyBase
    {
        private Seller _selectedSeller;

        public Seller SelectedSeller
        {
            get { return _selectedSeller; }
            set
            {
                _selectedSeller = value;
                OnPropertyChanged(nameof(SelectedSeller));
                OnPropertyChanged(nameof(TotalSales));
                OnPropertyChanged(nameof(Commission));
                OnPropertyChanged(nameof(MonthlyRent));
                OnPropertyChanged(nameof(Payout));
                OnPropertyChanged(nameof(AmountOwed));

            }
        }

        public decimal TotalSales
        {
            get
            {
                if (SelectedSeller == null)
                {
                    return 0;
                }

                return SelectedSeller.MonthlyEarnings.Sum();
            }
        }

        public decimal Commission
        {
            get
            {
                return TotalSales * 0.10m;
            }
        }
        public decimal MonthlyRent
        {
            get
            {
                if (SelectedSeller == null)
                {
                    return 0;
                }

                DateTime firstDayOfNextMonth =
                    new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
                int numberOfShelves = SelectedSeller.OwnedShelves.Count(shelf =>
                shelf.CancellationEffectiveDate == null ||
                shelf.CancellationEffectiveDate < firstDayOfNextMonth);

                if (numberOfShelves == 0)
                {
                    return 0;
                }
                else if (numberOfShelves == 1)
                {
                    return 850;
                }
                else if (numberOfShelves >= 3)
                {
                    return 825 * numberOfShelves;
                }
                else
                {
                    return 800 * numberOfShelves;
                }
            }
        }

        public decimal Payout
        {
            get
            {
                return TotalSales - Commission - MonthlyRent;
            }
        }

        public decimal AmountOwed
        {
            get
            {
                if (Payout < 0)
                {
                    return -Payout;
                }
                else
                {
                    return 0;
                }
            }
        }
    
    }
}