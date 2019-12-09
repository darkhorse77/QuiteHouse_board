using QuiteHouse_board.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiteHouse_board.Models.Logic
{
    public static class Actions
    {
        public static List<Boards> LoadBoardsList()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Boards.ToList();
            }
        }

        public static Boards LoadBoard(string boardDomain)
        {        
            using (ApplicationContext db = new ApplicationContext())
            {
                Boards board = db.Boards.Where(x => x.Domain == boardDomain).FirstOrDefault();
                board.Threads = LoadThreadsForBoard(board.Id);
                return board;
            }
        }

        public static Threads LoadThread(int threadMainPostId)
        {
            Threads thread = new Threads();
            using (ApplicationContext db = new ApplicationContext())
            {
                thread = db.Threads.Where(x => x.MainPostId == threadMainPostId).FirstOrDefault();
                thread.MainPost = db.Posts.Where(x => x.Id == thread.MainPostId).FirstOrDefault();
                thread.Posts = db.Posts.Where(x => x.ThreadId == thread.Id).ToList();
            }
            return thread;
        }

        private static List<Threads> LoadThreadsForBoard(int boardId)
        {
            List<Threads> threads = new List<Threads>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (Threads th in db.Threads.Where(x => x.BoardId == boardId))
                {
                    th.MainPost = db.Posts.Where(x => x.Id == th.MainPostId).FirstOrDefault();
                    th.Posts = db.Posts.Where(x => x.ThreadId == th.Id).ToList();
                    threads.Add(th);
                }
            }
            return threads;
        }

        public static void CreateThread(string message, int boardId, string image = null, string author = "Аноним")
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Threads thread = new Threads()
                {
                    BoardId = boardId,
                    MainPost = new Posts()
                    {
                        Image = image,
                        Message = message,
                        Author = author,
                        Time = DateTime.Now
                    }
                };
                db.Add(thread);
                db.SaveChanges();
            }
        }

        public static void DeleteThread(int threadId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Threads.Remove(db.Threads.Where(x => x.Id == threadId).FirstOrDefault());
                db.SaveChanges();
            }
        }

        public static void ReplyToThread(string message, int threadId, string image, string author = "Аноним")
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Posts post = new Posts()
                {
                    Message = message,
                    ThreadId = threadId,
                    Image = image,
                    Author = author,
                    Time = DateTime.Now
                };
                db.Posts.Add(post);
                db.SaveChanges();
            }
        }

        public static void DeletePost() { }

        public static void UpdatePost() { }
    }
}
