using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Todo project = await GetAPIAsync("http://localhost:8080/todo");


            string sResult = "API Result on /api/Projects/1: " + Environment.NewLine + "Name=" + project.Name + Environment.NewLine + "Description=" + project.Description;

            sResult += Environment.NewLine + "Id=" + project.Id;

            //MessageBox.Show(sResult, "API Read");

            Console.WriteLine(sResult);
        }

        //public async void OnGet()
        //{
        //    Project project = await GetAPIAsync("http://localhost:8080/todo");


        //    String sResult = "API Result on /api/Projects/1: " + Environment.NewLine + "Title=" + project.Title + Environment.NewLine + "Text=" + project.Text;

        //    sResult += Environment.NewLine + "URL=" + project.URL;

        //    //MessageBox.Show(sResult, "API Read");

        //    Console.WriteLine( sResult);
        //}
        public class Todo

        {

            //-------------< Class: Model_Project >-------------

            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }


            //-------------</ Class: Model_Project >-------------

        }

        static async Task<Todo> GetAPIAsync(string path)

        {

            Todo project = null;

            HttpResponseMessage response = await client.GetAsync(path);

            if (response.IsSuccessStatusCode)

            {
                project = await response.Content.ReadAsync<Todo>();

            }

            return project;

        }
    }
}
