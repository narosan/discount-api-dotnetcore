using System;
using ingressocom_promocodeAPI.Domain;
using ingressocom_promocodeAPI.Repositories.Interface;

namespace ingressocom_promocodeAPI.Services
{
    public class UtilService
    {
        private readonly ICheckoutRepository _checkoutRepository;
        public UtilService(ICheckoutRepository checkoutRepository)
        {
            _checkoutRepository = checkoutRepository;
        }
        
        public bool checkCurrentDayIsWeekend() {
            DayOfWeek currentDayOfDay = new DateTime().DayOfWeek;
            return currentDayOfDay == DayOfWeek.Saturday || currentDayOfDay == DayOfWeek.Sunday;
        }

        public bool checkMovieIsContemplated(Checkout checkout) {
            var selectedEvent = _checkoutRepository.GetEventById(checkout.Sessions.Event.Id);
            return selectedEvent.Result.isContemplated;
        }

        public bool checkTheatreIsContemplated(Checkout checkout) {
            var selectedTheatre = _checkoutRepository.GetTheatreById(checkout.Sessions.Theatre.Id);
            return selectedTheatre.Result.isContemplated;
        }

        public bool checkPromocodeIsValid(Promocode promocode) {
            return DateTime.Parse(promocode.EndDate).CompareTo(DateTime.Now) > 0;
        }

        public bool checkDateIsWeekend(DateTime date) {
            return date.CompareTo(DateTime.Now) > 0;
        }
    }
}