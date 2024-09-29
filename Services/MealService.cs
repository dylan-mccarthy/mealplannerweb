// This service interacts with the API to get, add, update, and delete meals from the database.

using System.Net.Http.Json;
using MealPlanner.Models;

namespace MealPlanner.Services
{
    public class MealService
    {
        private readonly HttpClient _http;

        public MealService(HttpClient http, IConfiguration config)
        {
            _http = http;
        }

        public async Task<List<Meal>> GetMeals()
        {
            return await _http.GetFromJsonAsync<List<Meal>>("meals");
        }

        public async Task<Meal> GetMeal(int id)
        {
            return await _http.GetFromJsonAsync<Meal>($"meals/{id}");
        }

        //Get meals by date
        public async Task<List<Meal>> GetMealsForDateAsync(DateTime date)
        {
            var dateString = date.ToString("yyyy-MM-dd");
            var result = await _http.GetFromJsonAsync<List<Meal>>($"/meals/date/{dateString}");
            if(result == null)
            {
                return new List<Meal>();
            }
            return result;
        }

        public async Task<HttpResponseMessage> AddMealAsync(Meal meal)
        {
            return await _http.PostAsJsonAsync("meals", meal);
        }

        public async Task<HttpResponseMessage> UpdateMealAsync(Meal meal)
        {
            return await _http.PutAsJsonAsync($"meals/{meal.Id}", meal);
        }

        public async Task<HttpResponseMessage> DeleteMealAsync(int id)
        {
            return await _http.DeleteAsync($"meals/{id}");
        }
    }
}
