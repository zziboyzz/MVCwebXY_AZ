using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectXYAZ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//
using Firebase.Database;
using Firebase.Database.Query;

namespace ProjectXYAZ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return View(new ChatData());
        }
        /*******************************************************/
        public async Task<ActionResult> Thongbao()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            var currentLoginTime = "haha";

            //Save non identifying data to Firebase
            var currentUserLogin = new ChatData() { Messages = currentLoginTime };
            var firebaseClient = new FirebaseClient("https://mvcwebdb-default-rtdb.asia-southeast1.firebasedatabase.app/");
            //Retrieve data from Firebase
            var dbMessages = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Messages")
              .OnceAsync<ChatData>();

            var messagesList = new List<string>();

            //Convert JSON data to original datatype
            foreach (var message in dbMessages)
            {
                messagesList.Add(message.Object.Messages);
            }
            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.messages = messagesList;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Thongbao(string ms)
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            //Save non identifying data to Firebase
            var currentUserLogin = new ChatData() { Messages = ms};
            var firebaseClient = new FirebaseClient("https://mvcwebdb-default-rtdb.asia-southeast1.firebasedatabase.app/");
            var result = await firebaseClient
              .Child("Users/" + userId + "/Messages")
              .PostAsync(currentUserLogin);

            //Retrieve data from Firebase
            var dbMessages = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Messages")
              .OnceAsync<ChatData>();

            var messagesList = new List<string>();

            //Convert JSON data to original datatype
            foreach (var message in dbMessages)
            {
                messagesList.Add(message.Object.Messages);
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.messages = messagesList.OrderByDescending(x => x);
            return View();
        }
       
        /*******************************************************/
        public async Task<ActionResult> Baigiang()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            var firebaseClient = new FirebaseClient("https://mvcwebdb-default-rtdb.asia-southeast1.firebasedatabase.app/");
            //Retrieve data from Firebase
            var dbMessages = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Messages")
              .OnceAsync<ChatData>();

            var messagesList = new List<string>();

            //Convert JSON data to original datatype
            foreach (var message in dbMessages)
            {
                messagesList.Add(message.Object.Messages);
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.messages = messagesList.OrderByDescending(x => x);
            return View();
        }
        /*******************************************************/
        public async Task<ActionResult> Tailieu()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            var firebaseClient = new FirebaseClient("https://mvcwebdb-default-rtdb.asia-southeast1.firebasedatabase.app/");
            //Retrieve data from Firebase
            var dbMessages = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Messages")
              .OnceAsync<ChatData>();

            var messagesList = new List<string>();

            //Convert JSON data to original datatype
            foreach (var message in dbMessages)
            {
                messagesList.Add(message.Object.Messages);
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.messages = messagesList.OrderByDescending(x => x);
            return View();
        }
        /*******************************************************/
        public async Task<ActionResult> Games()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            //Save non identifying data to Firebase
            var firebaseClient = new FirebaseClient("https://mvcwebdb-default-rtdb.asia-southeast1.firebasedatabase.app/");
           
            //Retrieve data from Firebase
            var dbMessages = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Messages")
              .OnceAsync<ChatData>();

            var messagesList = new List<string>();

            //Convert JSON data to original datatype
            foreach (var message in dbMessages)
            {
                messagesList.Add(message.Object.Messages);
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.messages = messagesList.OrderByDescending(x => x);
            return View();
        }

        /*******************************************************/
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }

}
