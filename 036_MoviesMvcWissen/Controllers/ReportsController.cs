﻿using _036_MoviesMvcWissen.Contexts;
using _036_MoviesMvcWissen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Controllers
{
    public class ReportsController : Controller
    {
        MoviesContext db = new MoviesContext();  // MovieReportModel and ReportsController
        public ActionResult Movies()
        {
            var movieQuery = db.Movies.AsQueryable();
            var directoryQuery = db.Directors.AsQueryable();
            var movieDirectoryQuery = db.MovieDirectors.AsQueryable();
            var reviewQuery = db.Reviews.AsQueryable();

            // inner join ile yapılışı
            //var query = from m in movieQuery // Paging, vahiyooooooo
            //            join md in movieDirectoryQuery
            //            on m.Id equals md.MovieId
            //            join d in directoryQuery
            //            on md.DirectorId equals d.Id
            //            join r in reviewQuery
            //            on m.Id equals r.MovieId
            //            select new MovieReportModel()
            //            {
            //                MovieId = m.Id,
            //                MovieName = m.Name,
            //                MovieProductionYear = m.ProductionYear,
            //                MovieBoxOfficeReturn = m.BoxOfficeReturn.HasValue ? m.BoxOfficeReturn.Value.ToString("C", new CultureInfo("tr")) : "",
            //                DirectorFullName = d.Name + d.Surname,
            //                DirectorRetired = d.Retired ? "Yes" : "No",
            //                ReviewContent = r.Content,
            //                ReviewRating = r.Rating,
            //                ReviewReviewer = r.Reviewer
            //            };

            // left outer join // ;_;

            var query = from m in movieQuery 
                        join md in movieDirectoryQuery 
                        on m.Id equals md.MovieId into movie_moviedirector
                        from sub_movie_moviedirector in movie_moviedirector.DefaultIfEmpty()

                        join d in directoryQuery
                        on sub_movie_moviedirector.DirectorId equals d.Id into moviedirector_director from sub_moviedirector_director in moviedirector_director.DefaultIfEmpty()

                        join r in reviewQuery
                        on m.Id equals r.MovieId into movie_review
                        from sub_movie_review in movie_review.DefaultIfEmpty()

                        select new MovieReportModel()
                        {
                            MovieId = m.Id,
                            MovieName = m.Name,
                            MovieProductionYear = m.ProductionYear,
                            _MovieBoxOfficeReturn = m.BoxOfficeReturn,
                            DirectorFullName = sub_moviedirector_director.Name + " " + sub_moviedirector_director.Surname,
                            _DirectorRetired = sub_moviedirector_director.Retired,
                            ReviewContent = sub_movie_review.Content,
                            ReviewRating = sub_movie_review.Rating,
                            ReviewReviewer = sub_movie_review.Reviewer
                        };

            var model = query.ToList().Select(e => new MovieReportModel()
            {


                MovieId = e.MovieId,
                MovieName = e.MovieName,
                MovieProductionYear = e.MovieProductionYear,
                MovieBoxOfficeReturn = e._MovieBoxOfficeReturn.HasValue ? e._MovieBoxOfficeReturn.Value.ToString("C", new CultureInfo("tr")) : "",
                DirectorFullName = e.DirectorFullName,
                DirectorRetired = e._DirectorRetired ? "Yes" : "No",
                ReviewContent = e.ReviewContent,
                ReviewRating = e.ReviewRating,
                ReviewReviewer = e.ReviewReviewer
            });
            return View(model);
        }

    }

}





