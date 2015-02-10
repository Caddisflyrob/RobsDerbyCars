using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.DAL
{
    public class DerbyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DerbyContext>
    //public class DerbyInitializer : System.Data.Entity.DropCreateDatabaseAlways<DerbyContext>
    {
        protected override void Seed(DerbyContext context)
        {
            var Cars = new List<Car>
            {
            new Car{CarName="Woody",PictureURL="Woody.jpg",ThumbnailURL="WoodyThumb.jpg", Description=" Woody with surf board ", Owner = "Rob Callahan"},
            new Car{CarName="Brookie",PictureURL="Brookie.jpg",ThumbnailURL="BrookieThumb.jpg", Description=" Brooktrout ", Owner = "Rob Callahan"},
            new Car{CarName="Freedom",PictureURL="Fredom.jpg",ThumbnailURL="FredomThumb.jpg", Description=" Eagle and Flag ", Owner = "Rob Callahan"},
            new Car{CarName="Speeder",PictureURL="Landspeeder.jpg",ThumbnailURL="LandspeederThumb.jpg", Description=" Star Wars Landspeeder ", Owner = "Andrew Callahan"},
            new Car{CarName="Crusin' Calculator",PictureURL="Pencil.jpg",ThumbnailURL="PencilThumb.jpg", Description="Pencil", Owner = "Karina Callahan"},
            };
            Cars.ForEach(c => context.Cars.Add(c)); //Lamda expression used to populate the Cars table in the DB 
            context.SaveChanges(); //Saves changes to the DB



            var Comments = new List<Comment>
            {
            new Comment{Name = "Joe King", CommentText="This is a great car", CarIdNum = 1,},
            new Comment{Name = "Frank Dibert", CommentText="Makes me want to go fishing.", CarIdNum = 2,},
            new Comment{Name = "Sarah Callahan", CommentText="How Patriotic. I love it!", CarIdNum = 3,},
            new Comment{Name = "Nathan Wirth", CommentText="May the force be with you.", CarIdNum = 4,},
            new Comment{Name = "Sarah Callahan", CommentText="I feel like doing my homework. Great idea for a PWD!", CarIdNum = 5,},
            new Comment{Name = "Glen Nichols", CommentText="What kind of fly did you use to catch it?", CarIdNum = 2,},
            new Comment{Name = "Frank Dibert", CommentText="Surfs up! Great car; I love the detail.", CarIdNum = 1,},
            new Comment{Name = "Chris Callahan", CommentText="Good job! It's very realistic.", CarIdNum = 2,}
            };
            Comments.ForEach(c => context.Comments.Add(c)); //Lamda expression used to populate the Comments table in the DB
            context.SaveChanges();//Saves changes to the DB


            var Heats = new List<Heat>
            {
            new Heat{FirstRacer=1, SecondRacer=2 ,FirstRacerIsWinner =true, IsComplete= true },
            new Heat{FirstRacer=1, SecondRacer=3 ,FirstRacerIsWinner =false, IsComplete= true },
            new Heat{FirstRacer=1, SecondRacer=4 ,FirstRacerIsWinner =true, IsComplete= false },
            new Heat{FirstRacer=2, SecondRacer=3 ,FirstRacerIsWinner =true, IsComplete= false },
            new Heat{FirstRacer=2, SecondRacer=4 ,FirstRacerIsWinner =true, IsComplete= false },
            new Heat{FirstRacer=3, SecondRacer=4 ,FirstRacerIsWinner =true, IsComplete= false },
            };
            Heats.ForEach(h => context.Heats.Add(h)); //Lamda expression used to populate the Heats table in the DB
            context.SaveChanges(); //Saves changes to the DB

            var Racers = new List<Racer>
            {
            new Racer{FirstName="Andrew", LastName="Callahan" ,Age =15, Division= "Expedition Rangers" },
            new Racer{FirstName="Chase", LastName="Napper" ,Age =12, Division= "Adventure Rangers" },
            new Racer{FirstName="Brandon", LastName="Running" ,Age =14, Division= "Expedition Rangers" },
            new Racer{FirstName="Rob", LastName="Callahan" ,Age =45, Division= "Adult" },
            };
            Racers.ForEach(r => context.Racers.Add(r)); //Lamda expression used to populate the Racers table in the DB
            context.SaveChanges(); //Saves changes to the DB
        }
    }
}
