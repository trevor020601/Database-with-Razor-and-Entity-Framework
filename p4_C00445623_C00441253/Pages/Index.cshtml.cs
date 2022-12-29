/*
Author:        Rodney Harris and Trevor Karl
CLID:          C00445623 and C00441253 
Class:         CMPS 358
Assignment:    Project #4
Due Date:      November 20, 2022
Description:   This file includes the back-end LINQ queries for searching 
               the database.          
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace p4_C00445623_C00441253.Pages;

/*
 * IndexModel : PageModel
 *
 * Razor page for binding the user input properties and connecting to index 
*/
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    /*
     * BindProperties as parameters for user input to send to the database
     * for querying a specific/partial author, publisher, or title
     */
    [BindProperty]
    public string? Letter { get; set; }

    [BindProperty]
    public string? AuthorPartial { get; set; }

    [BindProperty]
    public string? PublisherPartial { get; set; }

    [BindProperty]
    public string? TitlePartial { get; set; }

}

/*
 * AuthorsByFirstLetter
 *
 * Class for getting author names from a single letter from the user
*/
public class AuthorsByFirstLetter 
{
    /*
     * ListAuthorsByFirstLetter
     *
     * Parameter: letter (string / null)
     *
     * Output: List<string> / null
     *
     * Description: Queries the database with a letter and 
     *              returns a list with author names.
    */
    public static List<string>? ListAuthorsByFirstLetter(string? letter) 
    {
        if(letter == null) return null;

        using var db = new p4_C00445623_C00441253();

        try
        {
            letter = letter.ToUpper();

            var results = 
                from auth in db.Authors
                where auth.Author1.Substring(0,1) == letter
                orderby auth.Author1
                select auth;
            
            if(!results.Any())
            {
                var errorList = new List<string>();
                errorList.Add("");
                return errorList;
            }

            var authors = new List<string>();
            foreach(var a in results)
            {
                authors.Add($"{a.Author1}");
            }
            return authors;
        }
        catch
        {
            var errorList = new List<string>();
            errorList.Add("");
            return errorList;
        }
    }
}

/*
 * AuthorsByPartial
 *
 * Class for getting author names based on a partial/full name passed
*/
public class AuthorsByPartial 
{
    /*
     * ListAuthorsByPartialName
     *
     * Parameter: name (string / null)
     *
     * Output: List<string> / null
     *
     * Description: Queries the database for a full/partial author name and 
     *              returns a list with author names.
    */
    public static List<string>? ListAuthorsByPartialName(string? name)
    {
        if(name == null) return null;

        using(var db = new p4_C00445623_C00441253())
        {
            try
            {
                name = name.ToUpper();

                var results = 
                    from auth in db.Authors
                    where auth.Author1.ToUpper().Contains(name)
                    orderby auth.Author1
                    select auth;

                if(!results.Any())
                {
                    var errorList = new List<string>();
                    errorList.Add("");
                    return errorList;
                }

                var authors = new List<string>();
                foreach(var a in results) 
                {
                    authors.Add($"{a.Author1}");
                }
                return authors;
            }
            catch
            {
                var errorList = new List<string>();
                errorList.Add("");
                return errorList;
            }
        }
    }
}

/*
 * MatchPublishersWithAuthors
 *
 * Class for getting authors associated with the publisher passed 
*/
public class MatchPublishersWithAuthors 
{
    /*
     * ListMatchPublishersWithAuthors
     *
     * Parameter: pub (string / null)
     *
     * Output: List<string> / null
     *
     * Description: Queries the database for a full/partial publisher and 
     *              returns a list with author and publisher names.
    */
    public static List<string>? ListMatchPublishersWithAuthors(string? pub)
    {
        if(pub == null) return null;

        using(var db = new p4_C00445623_C00441253()) 
        {
            try
            {
                pub = pub.ToUpper();

                var results = 
                    from p in db.Publishers
                    where p.Name.ToUpper().Contains(pub)
                    join t in db.Titles on p.PubId equals t.PubId
                    join ta in db.TitleAuthors on t.Isbn.Trim() equals ta.Isbn.Trim()
                    join a in db.Authors on ta.AuId equals a.AuId
                    orderby a.Author1
                    select p.Name + "; " + a.Author1;

                if(!results.Any())
                {
                    var errorList = new List<string>();
                    errorList.Add("");
                    return errorList;
                }

                var publisher = new List<string>();

                foreach(var a in results) {
                    publisher.Add($"{a}");
                }
                return publisher;
            }
            catch
            {
                var errorList = new List<string>();
                errorList.Add("");
                return errorList;
            }
        }
    }
}

/*
 * TitleAssociatedInformation
 *
 * Class for getting associated information from a title input
*/
public class TitleAssociatedInformation
{
    /*
     * ListTitleAssociatedInformation
     *
     * Parameter: title (string / null)
     *
     * Output: List<string> / null
     * 
     * Description: Queries the database for a full/partial title and returns
     *              a list with the title, author, publisher, and publication
     *              date.
    */
    public static List<string>? ListTitleAssociatedInformation(string? title)
    {
        if(title == null) return null;

        using(var db = new p4_C00445623_C00441253())
        {
            try
            {
                title = title.ToUpper();

                var results = 
                    from t in db.Titles
                    where t.Title1.ToUpper().Contains(title)
                    join ta in db.TitleAuthors on t.Isbn.Trim() equals ta.Isbn.Trim()
                    join a in db.Authors on ta.AuId equals a.AuId
                    join p in db.Publishers on t.PubId equals p.PubId
                    orderby t.Title1, a.Author1
                    select t.Title1 + "; " + a.Author1 + "; " + p.Name + 
                            "; " + t.YearPublished;

                if(!results.Any())
                {
                    var errorList = new List<string>();
                    errorList.Add("");
                    return errorList;
                }

                var info = new List<string>();
                foreach(var tl in results) {
                    info.Add($"{tl}");
                }
                return info;
            }
            catch
            {
                var errorList = new List<string>();
                errorList.Add("");
                return errorList;            
            }
        }
    }
}
