using BusinessObjects.Models;
using BusinessObjects.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Steps
{
    public class UISteps
    {
        public static LoginPage Login(UserModel user)
        {
            new LoginPage().
                OpenPage().
                TryToLogin(user);

            return new LoginPage();
        }

        public static CalendarPage GoToCalendar(UserModel user)
        {
            new LoginPage().
                OpenPage().
                TryToLogin(user).
                OpenCalendarPage();

            return new CalendarPage();
        }

        public static CaloricCalculatorFrame GoToCaloricCalculator(UserModel user) 
        {
            new LoginPage().
                OpenPage().
                TryToLogin(user).
                OpenCaloricCalculatorPage();

            return new CaloricCalculatorFrame();
        }

        public static PaceCalculatorFrame GoToPaceCalculator(UserModel user) 
        {
            new LoginPage().
                OpenPage().
                TryToLogin(user).
                OpenPaceCalculatorPage();

            return new PaceCalculatorFrame();
        }
    }
}
