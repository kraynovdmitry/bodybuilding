using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET_APP.Models.Repository
{
    public class Repository
    {
        private ProgramContext context = new ProgramContext();

        public IEnumerable<Competition> Competitions
        {
            get { return context.Competitions; }
        }

        public IEnumerable<Athlete> Athletes
        {
            get { return context.Athletes; }
        }

        public IEnumerable<Judge> Judges
        {
            get { return context.Judges; }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }

        public IEnumerable<CompetitionAthlete> CompetitionAthletes
        {
            get { return context.CompetitionAthletes; }
        }

        public IEnumerable<CompetitionCategory> CompetitionCategories
        {
            get { return context.CompetitionCategories; }
        }

        public IEnumerable<CompetitionJudge> CompetitionJudges
        {
            get { return context.CompetitionJudges; }
        }

        public IEnumerable<AthleteCategory> AthleteCategories
        {
            get { return context.AthleteCategories; }
        }

        public IEnumerable<Rating> Ratings
        {
            get { return context.Ratings; }
        }

        public int GetRating(int ct, int at, int j)
        {
            var a = Ratings.Where(c => c.Category == ct && c.Athlete == at && c.Judge == j);
            if (!a.Any())
                return -1;
            return a.First().Place;
        }

        public bool GetRating(int ct, int j)
        {
            var a = Ratings.Where(c => c.Category == ct && c.Judge == j).ToArray();
            if (!a.Any())
                return false;
            return true;
        }

        public Athlete GetAthleteById(int id)
        {
            var a = Athletes.Where(c => c.Id == id);
            if (!a.Any())
            {
                Athlete b = new Athlete();
                b.Id = 0;
                return b;
            }
            return a.First();
        }

        public Competition GetCompetitionById(int id)
        {
            var a = Competitions.Where(c => c.Id == id);
            if (!a.Any())
            {
                Competition b = new Competition();
                b.Id = 0;
                return b;
            }
            return a.First();
        }
               

        public IEnumerable<Category> GetCategoriesByCompetition(int currentCompetition)
        {
            var tmp = CompetitionCategories.Where(c => c.Competition == currentCompetition);

            return (from a in Categories
                      join b in tmp
                      on a.Id equals b.Category
                      select new Category 
                      { 
                          Id = a.Id,
                          Name = a.Name,
                          Type = a.Type,
                          N = a.N
                      } );
        }

        public IEnumerable<Judge> GetJudgesByCompetition(int currentCompetition)
        {
            var tmp = CompetitionJudges.Where(c => c.Competition == currentCompetition);

            return (from a in Judges
                    join b in tmp
                    on a.Id equals b.Judge
                    select new Judge
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Login = a.Login,
                        Password = a.Password
                    });
        }

        public int GetCompetitionByJudge(int judge)
        {
            var tmp = CompetitionJudges.Where(c => c.Judge == judge);
            if (!tmp.Any())
                return 0;
            return tmp.First().Competition;
        }

        public IEnumerable<Athlete> GetAthletesByCompetition(int currentCompetition)
        {
            var tmp = CompetitionAthletes.Where(c => c.Competition == currentCompetition);

            return (from a in Athletes
                    join b in tmp
                    on a.Id equals b.Athlete
                    select new Athlete
                    {
                        Id = a.Id,
                        Name = a.Name
                    });
        }

        public IEnumerable<Athlete> GetAthletesByCategory(int currentCategory)
        {
            var tmp = AthleteCategories.Where(c => c.Category == currentCategory);

            return (from a in Athletes
                    join b in tmp
                    on a.Id equals b.Athlete
                    select new Athlete
                    {
                        Id = a.Id,
                        Name = a.Name
                    });
        }

        public void SaveAthlete( Athlete a )
        {
            if (a.Id == 0)
            {
                a = context.Athletes.Add(a);
            }
            else
            {
                Athlete b = context.Athletes.Find(a.Id);
                if (b != null)
                {
                    b.Name = a.Name;
                }
            }
            context.SaveChanges();
        }

        public void SaveJudge(Judge a)
        {
            if (a.Id == 0)
            {
                a = context.Judges.Add(a);
            }
            else
            {
                Judge b = context.Judges.Find(a.Id);
                if (b != null)
                {
                    b.Name = a.Name;
                    b.Login = a.Login;
                    b.Password = a.Password;
                }
            }
            context.SaveChanges();
        }

        public void SaveCompetition(Competition a)
        {
            if (a.Id == 0)
            {
                a = context.Competitions.Add(a);
            }
            else
            {
                Competition b = context.Competitions.Find(a.Id);
                if (b != null)
                {
                    b.Name = a.Name;
                    b.State = a.State;
                }
            }
            context.SaveChanges();
        }

        public void SaveCategory(Category a)
        {
            if (a.Id == 0)
            {
                a = context.Categories.Add(a);
            }
            else
            {
                Category b = context.Categories.Find(a.Id);
                if (b != null)
                {
                    b.Name = a.Name;
                    b.Type = a.Type;
                    b.N = a.N;
                }
            }
            context.SaveChanges();
        }

        public void SaveRating(Rating a)
        {
            a = context.Ratings.Add(a);
            context.SaveChanges();
        }

        public void SaveCompetitionAthlete(int competition, int athlete)
        {
            var list = CompetitionAthletes.Where(c => c.Competition == competition && c.Athlete == athlete);
            if (!list.Any())
            {
                CompetitionAthlete a = new CompetitionAthlete();
                a.Id = 0;
                a.Athlete = athlete;
                a.Competition = competition;
                context.CompetitionAthletes.Add(a);
            }
            context.SaveChanges();
        }

        public void SaveCompetitionJudge(int competition, int judge)
        {
            var list = CompetitionJudges.Where(c => c.Competition == competition && c.Judge == judge);
            if (!list.Any())
            {
                CompetitionJudge a = new CompetitionJudge();
                a.Id = 0;
                a.Judge = judge;
                a.Competition = competition;
                context.CompetitionJudges.Add(a);
            }
            context.SaveChanges();
        }

        public void SaveCompetitionCategory(int competition, int category)
        {
            var list = CompetitionCategories.Where(c => c.Competition == competition && c.Category == category);
            if (!list.Any())
            {
                CompetitionCategory a = new CompetitionCategory();
                a.Id = 0;
                a.Category = category;
                a.Competition = competition;
                context.CompetitionCategories.Add(a);
            }
            context.SaveChanges();
        }

        public void SaveAthleteCategory(int athlete, int category)
        {
            var list = AthleteCategories.Where(c => c.Athlete == athlete && c.Category == category);
            if (!list.Any())
            {
                AthleteCategory a = new AthleteCategory();
                a.Id = 0;
                a.Category = category;
                a.Athlete = athlete;
                context.AthleteCategories.Add(a);
            }
            context.SaveChanges();
        }

        public void DeleteAthleteCategory(int athlete, int category)
        {
            var list = AthleteCategories.Where(c => c.Athlete == athlete && c.Category == category);
            if (!list.Any())
                return;
            context.AthleteCategories.Remove(list.First());
            context.SaveChanges();
        }

        public string LoginUser(string login, string password, ref int num)
        {
            if (string.IsNullOrEmpty(login))
                return "Не заполнено поле \"Логин\".";
            if (string.IsNullOrEmpty(password))
                return "Не заполнено поле \"Пароль\".";
            var users = context.Judges.Where(c => c.Login == login);
            if (!users.Any())
                return "Пользователя с таким логином не существует.";
            var user = users.First();
            if (user.Password != password)
                return "Пароль не верный.";
            num = user.Id;
            return null;
        }

    }
}