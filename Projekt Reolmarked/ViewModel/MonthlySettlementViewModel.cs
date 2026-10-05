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
                OnPropertyChanged(nameof(Comission));
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

        public decimal Comission
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

                return SelectedSeller.MonthlyPayment;
            }
        }

        public decimal Payout
        {
            get
            {
                return TotalSales - Comission - MonthlyRent;
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