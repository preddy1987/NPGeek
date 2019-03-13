using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface INPGeekDAL
    {
        List<Park> GetAllParks();
        Park GetPark(string ParkCode);
        void SaveNewSurvey(Survey survey);
        List<SurveyResultsViewModel> GetSurveyResults();
    }
}
