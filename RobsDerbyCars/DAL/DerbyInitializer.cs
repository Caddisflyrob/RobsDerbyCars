using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.DAL
{
    //public class DerbyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DerbyContext>
    public class DerbyInitializer : System.Data.Entity.DropCreateDatabaseAlways<DerbyContext>
    {
        protected override void Seed(DerbyContext context)
        {
            var Cars = new List<Car>
            {
            new Car{CarName="Woody",PictureURL="Woody.jpg",ThumbnailURL="WoodyThumb.jpg", Description=" Woody with surf board ", Owner = "Rob Callahan"},
            new Car{CarName="Rainbow",PictureURL="Rainbow.jpg",ThumbnailURL="RainbowThumb.jpg", Description=" I built this Rainbow trout to honor flyfishing, my other hobby.", Owner = "Rob Callahan"},
            new Car{CarName="Freedom",PictureURL="Freedom.jpg",ThumbnailURL="FreedomThumb.jpg", Description=" Eagle and Flag ", Owner = "Rob Callahan"},
            new Car{CarName="Speeder",PictureURL="Landspeeder.jpg",ThumbnailURL="LandspeederThumb.jpg", Description=" Star Wars Landspeeder ", Owner = "Andrew Callahan"},
            new Car{CarName="Crusin' Calculator",PictureURL="Pencil.jpg",ThumbnailURL="PencilThumb.jpg", Description="Pencil", Owner = "Karina Callahan"},
            new Car{CarName="Gone Fishin'",PictureURL="Fishing.jpg",ThumbnailURL="FishingThumb.jpg", Description="Fishing Boat with tackle and Gear", Owner = "Rob Callahan"},
            new Car{CarName="Attack",PictureURL="Attack.jpg",ThumbnailURL="AttackThumb.jpg", Description="Giant Squid attacking a Sperm Whale", Owner = "Rob Callahan"},
            new Car{CarName="Jaguar",PictureURL="Jaguar.jpg",ThumbnailURL="JaguarThumb.jpg", Description="Jaguar D type", Owner = "Ray Callahan"},
            new Car{CarName="Polizei",PictureURL="Polizei.jpg",ThumbnailURL="PolizeiThumb.jpg", Description="Porsche 911 German Police car ", Owner = "Ray Callahan"},
            new Car{CarName="GoldenX",PictureURL="GoldenX.jpg",ThumbnailURL="GoldenXThumb.jpg", Description="Futuristic sports car modeled from a 1973 Matchbox car named GoldenX  ", Owner = "Rob Callahan"},
            new Car{CarName="Crazy 8",PictureURL="Crazy8.jpg",ThumbnailURL="Crazy8Thumb.jpg", Description="Race car designed from a toy matchbox car ", Owner = "Chris Callahan"},
            new Car{CarName="Gold Fever",PictureURL="GoldFever.jpg",ThumbnailURL="GoldFeverThumb.jpg", Description="Futuristic sporst car ", Owner = "Martin Callahan"},
            new Car{CarName="Totem",PictureURL="Totem.jpg",ThumbnailURL="TotemThumb.jpg", Description="Totem Pole ", Owner = "Rob Callahan"},
            new Car{CarName="Mother of Pearl",PictureURL="MotherOfPearl.jpg",ThumbnailURL="MotherOfPearlThumb.jpg", Description="Wedge car painted with Pearl nail polish ", Owner = "Ray Callahan"},
            new Car{CarName="Formula 1",PictureURL="Formula1.jpg",ThumbnailURL="Formula1Thumb.jpg", Description="This was the first Pinewood derby I watched being made. My Dad and Brother, Martin, built it in the early 1970's. Over the years it has sustained extensive damage. The tail spoiler is missing and if I remember corectly, there used to be a driver in the cockpit. ", Owner = "Martin Callahan"},
            new Car{CarName="Spark",PictureURL="Spark.jpg",ThumbnailURL="SparkThumb.jpg", Description="I built this car back in the late 1970's. Although it it is a nice, slick design, this is the only car I ever built that was not fast enough to qualify for a race.", Owner = "Rob Callahan"},
            new Car{CarName="Lil' Mike",PictureURL="LilMike.jpg",ThumbnailURL="LilMikeThumb.jpg", Description="Cool car made by my brother Martin. ", Owner = "Martin Callahan"},
            new Car{CarName="Slick 5",PictureURL="Slick5.jpg",ThumbnailURL="Slick5Thumb.jpg", Description="Flat Racecar. ", Owner = "Martin Callahan"},
            new Car{CarName="Grand Prix",PictureURL="GrandPrix.jpg",ThumbnailURL="GrandPrixThumb.jpg", Description="Blue Racecar with rear engine scoop ", Owner = "Ray Callahan"},
            new Car{CarName="Roadster",PictureURL="Roadster.jpg",ThumbnailURL="RoadsterThumb.jpg", Description="Hot Rod Roadster", Owner = "Martin Callahan"},
            new Car{CarName="Lightning McQueen",PictureURL="LightningMcQueen.jpg",ThumbnailURL="LightningMcQueenThumb.jpg", Description="From the Disney Pixar Movie Cars ", Owner = "Sarah Callahan"},
            new Car{CarName="Royal Rangers Coupe",PictureURL="RoyalRangerCoupe.jpg",ThumbnailURL="RoyalRangerCoupeThumb.jpg", Description="Short squatty car with fenders", Owner = "Andrew Callahan"},
            new Car{CarName="Banana",PictureURL="Banana.jpg",ThumbnailURL="BananaThumb.jpg", Description="Banana", Owner = "Sarah Callahan"},
            new Car{CarName="Royal Ranger NASCAR ",PictureURL="RoyalRangerNASCAR.jpg",ThumbnailURL="RoyalRangerNASCARThumb.jpg", Description="NASCAR", Owner = "Andrew Callahan"},
            new Car{CarName="School Bus",PictureURL="SchoolBus.jpg",ThumbnailURL="SchoolBusThumb.jpg", Description="My son Andrew's first PWD ", Owner = "Andrew Callahan"},
            new Car{CarName="CCA School Bus ",PictureURL="CCA.jpg",ThumbnailURL="CCAThumb.jpg", Description="Callahan Christian Acadamy School bus with all the students from my wife's school in 2005-2006. She is driving the bus. ", Owner = "Karina Callahan"},
            new Car{CarName="Weird Purple Car ",PictureURL="Purple.jpg",ThumbnailURL="PurpleThumb.jpg", Description="Racecar with bubble canopy", Owner = "Andrew Callahan"},
            new Car{CarName="Strawberry Shortcake Car",PictureURL="StrawberryShortCake.jpg",ThumbnailURL="StrawberryShortCakeThumb.jpg", Description="My daughter's first car. She loved Strawberry Shortcake. ", Owner = "Sarah Callahan"},
            new Car{CarName="Crayon",PictureURL="Crayon.jpg",ThumbnailURL="CrayonThumb.jpg", Description="Crayon", Owner = "Karina Callahan"},
            new Car{CarName="Wii Remote",PictureURL="WiiRemote.jpg",ThumbnailURL="WiiRemoteThumb.jpg", Description="Remote controller for the Wii gaming console. Press A, B, Up, Up, Down ", Owner = "Andrew Callahan"},
            new Car{CarName="Princess",PictureURL="Princess.jpg",ThumbnailURL="PrincessThumb.jpg", Description="Disney Cinderella Princess car driven by my daughter, Sarah.", Owner = "Sarah Callahan"},
            new Car{CarName="Bullet",PictureURL="Bullet.jpg",ThumbnailURL="BulletThumb.jpg", Description="Bullet", Owner = "Andrew Callahan"},
            new Car{CarName="Inchworm",PictureURL="Inchworm.jpg",ThumbnailURL="InchwormThumb.jpg", Description="Inchworm won double trophies for \"Best in Show\" and \"Fastest Over-All Car\".", Owner = "Sarah Callahan"},
            new Car{CarName="Wooden Dutch Shoe ",PictureURL="Holland.jpg",ThumbnailURL="HollandThumb.jpg", Description="Wooden Shoe", Owner = "Sarah Callahan"},
            new Car{CarName="Old Fashoned Indy car ",PictureURL="OldIndyCar.jpg",ThumbnailURL="OldIndyCarThumb.jpg", Description="Old style race car", Owner = "Andrew Callahan"},
            new Car{CarName="Warthog ",PictureURL="Warthog.jpg",ThumbnailURL="WarthogThumb.jpg", Description="For all you Halo fans out there; You already know the Mk 41 Warthog is used by practically all UNSC ground forces. This is a great rendition of the all-terrain vehicle from the Halo video game. ", Owner = "Andrew Callahan"},
            new Car{CarName="Snake",PictureURL="Snake.jpg",ThumbnailURL="SnakeThumb.jpg", Description="Green snake ", Owner = "Rob Callahan"},
            new Car{CarName="Sluggo",PictureURL="Sluggo.jpg",ThumbnailURL="SluggoThumb.jpg", Description="For being a Slug, it was remarkably fast. It won second place for speed.", Owner = "Rob Callahan"},
            new Car{CarName="The Alphabetizer",PictureURL="Alphabetizer.jpg",ThumbnailURL="AlphabetizerThumb.jpg", Description="Fhe complete alphabet carved into a car. As you can imagine, It took lots of scroll saw work. ", Owner = "Karina Callahan"},
            new Car{CarName="Choo Choo ",PictureURL="ChooChoo .jpg",ThumbnailURL="ChooChooThumb.jpg", Description="Old Steam Engine Train", Owner = "Rob Callahan"},
            new Car{CarName="Rub-a-Dub-Dub ",PictureURL="Rub-a-Dub-Dub.jpg",ThumbnailURL="Rub-a-Dub-DubThumb.jpg", Description="Bathtub complete with rubber ducky and water pipes. ", Owner = "Rob Callahan"},
            new Car{CarName="Westward Ho!",PictureURL="Westward-Ho.jpg",ThumbnailURL="Westward-HoThumb.jpg", Description="Covered wagon", Owner = "Rob Callahan"},
            new Car{CarName="Pinewood Derby Monster ",PictureURL="Monster.jpg",ThumbnailURL="MonsterThumb.jpg", Description="This was my first Pinewood Derby car. It won second place for show in the state of Massachucetts back in 1974. ", Owner = "Rob Callahan"},
            new Car{CarName="Insideout Pinwood Derby Car",PictureURL="InsideoutPWD.jpg",ThumbnailURL="InsideoutPWDThumb.jpg", Description="There is unique creativity in this racecar cut from the inside of the block of wood. It won first place in speed and scond in show.", Owner = "Andrew Callahan"},
            
            
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


            /*
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
            */

           /* var Div = new List<RaceDivision>
            {
                new RaceDivision{Division="Expedition Rangers"},
                new RaceDivision{Division="Adventure Rangers"},
                new RaceDivision{Division="Discovery Rangers"},
                new RaceDivision{Division="Ranger Kids"},
                new RaceDivision{Division="Adult"},
             };
            Div.ForEach(d => context.RaceDivisions.Add(d)); //Lamda expression used to populate the Racers table in the DB
            context.SaveChanges(); //Saves changes to the DB
            */




            var Racers = new List<Racer>
            {
            new Racer{FirstName="Andrew", LastName="Callahan" , Division= "Expedition Rangers" },
            new Racer{FirstName="Brandon", LastName="Running" , Division= "Expedition Rangers" },
            new Racer{FirstName="Mason", LastName="Parker" , Division= "Expedition Rangers" },
            new Racer{FirstName="Daniel", LastName="Callahan" , Division= "Expedition Rangers" },
            new Racer{FirstName="Madline", LastName="Callahan" , Division= "Expedition Rangers" },

            new Racer{FirstName="Chase", LastName="Napper" , Division= "Adventure Rangers" },
            new Racer{FirstName="Kenton", LastName="Sparks" , Division= "Adventure Rangers" },
            new Racer{FirstName="Chris", LastName="Delano" , Division= "Adventure Rangers" },
            new Racer{FirstName="Sarah", LastName="Callahan" , Division= "Adventure Rangers" },
           

            new Racer{FirstName="Jett", LastName="LastName" , Division= "Discovery Rangers" },
            new Racer{FirstName="Jeremy", LastName="Vargus" , Division= "Discovery Rangers" },
            new Racer{FirstName="Matthew", LastName="Anderson" , Division= "Discovery Rangers" },
            new Racer{FirstName="Eric", LastName="Fredrick" , Division= "Discovery Rangers" },
            new Racer{FirstName="Jenny", LastName="Smith" , Division= "Discovery Rangers" },
            new Racer{FirstName="Dooders", LastName="Callahan" , Division= "Discovery Rangers" },

            new Racer{FirstName="Ethan", LastName="Donaldson" , Division= "Ranger Kids" },
            new Racer{FirstName="Grace", LastName="Running" , Division= "Ranger Kids" },
            new Racer{FirstName="Emma", LastName="Donaldson" , Division= "Ranger Kids" },
            new Racer{FirstName="Bat", LastName="Man" , Division= "Ranger Kids" },
            new Racer{FirstName="Super", LastName="Man" , Division= "Ranger Kids"},

            new Racer{FirstName="Rob", LastName="Callahan" , Division= "Adult" },
            new Racer{FirstName="Karina", LastName="Callahan" , Division= "Adult" },
            new Racer{FirstName="Ed", LastName="Powell" , Division= "Adult" },
            new Racer{FirstName="Glen", LastName="Nichols" , Division= "Adult" },
            new Racer{FirstName="Keith", LastName="Blunk" , Division= "Adult" },
            new Racer{FirstName="Larry", LastName="Macnaughton" , Division= "Adult" },
            };
            Racers.ForEach(r => context.Racers.Add(r)); //Lamda expression used to populate the Racers table in the DB
            context.SaveChanges(); //Saves changes to the DB
        }
    }
}
