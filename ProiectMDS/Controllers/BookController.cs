using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectMDS.DTOs;
using ProiectMDS.Models;
using ProiectMDS.Repositories.BookRepository;
using ProiectMDS.Repositories.WriterRepository;
using ProiectMDS.Repositories.BookWriterRepository;
using ProiectMDS.Repositories.LibraryRepository;
using ProiectMDS.Repositories.BookLibraryRepository;
using ProiectMDS.Repositories.PublisherRepository;
using ProiectMDS.Repositories.BookPublisherRepository;


namespace ProiectMDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookRepository IBookRepository { get; set; }
        public IWriterRepository IWriterRepository { get; set; }
        public IBookWriterRepository IBookWriterRepository { get; set; }
        public ILibraryRepository ILibraryRepository { get; set; }
        public IBookLibraryRepository IBookLibraryRepository { get; set; }
        public IPublisherRepository IPublisherRepository { get; set; }
        public IBookPublisherRepository IBookPublisherRepository { get; set; }

        public BookController(IBookRepository bookrepository, IWriterRepository writerrepository, IBookWriterRepository bookwriterrepository, ILibraryRepository libraryrepository, IBookLibraryRepository booklibraryrepository, IPublisherRepository publisherrepository, IBookPublisherRepository bookpublisherrepository)
        {
            IBookRepository = bookrepository;
            IWriterRepository = writerrepository;
            IBookWriterRepository = bookwriterrepository;
            ILibraryRepository = libraryrepository;
            IBookLibraryRepository = booklibraryrepository;
        }
        // GET: api/Album
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return IBookRepository.GetAll();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public BookDetailsDTO Get(int id)
        {
            Book Book = IBookRepository.Get(id);
            BookDetailsDTO MyBook = new BookDetailsDTO()
            {
                Name = Book.Name,
                Popularity = Book.Popularity,
                PublicationYear = Book.PublicationYear
            };
            IEnumerable<BookWriter> MyBookWriters = IBookWriterRepository.GetAll().Where(x => x.BookId == Book.Id);
            if (MyBookWriters != null)
            {
                List<string> BookWriterList = new List<string>();
                foreach (BookWriter MyBookWriter in MyBookWriters)
                {
                    Writer MyWriter = IWriterRepository.GetAll().SingleOrDefault(x => x.Id == MyBookWriter.Id);
                    BookWriterList.Add(MyWriter.Name);
                }
                MyBook.WriterName = BookWriterList;
            }

            IEnumerable<BookLibrary> MyLibraryBooks = IBookLibraryRepository.GetAll().Where(x => x.BookId == Book.Id);
            if (MyLibraryBooks != null)
            {
                List<string> LibraryBookList = new List<string>();
                foreach (BookLibrary MyLibraryBook in MyLibraryBooks)
                {
                    Library MyLibrary = ILibraryRepository.GetAll().SingleOrDefault(x => x.Id == MyLibraryBook.Id);
                    LibraryBookList.Add(MyLibrary.Name);
                }
                MyBook.LibraryName = LibraryBookList;
            }

            IEnumerable<BookPublisher> MyPublisherBooks = IBookPublisherRepository.GetAll().Where(x => x.BookId == Book.Id);
            if (MyPublisherBooks != null)
            {
                List<string> PublisherBookList = new List<string>();
                foreach (BookPublisher MyPublisherBook in MyPublisherBooks)
                {
                    Publisher MyPublisher = IPublisherRepository.GetAll().SingleOrDefault(x => x.Id == MyPublisherBook.Id);
                    PublisherBookList.Add(MyPublisher.Name);
                }
                MyBook.PublisherName = PublisherBookList;
            }
            return MyBook;
        }
        // POST: api/Book
        [HttpPost]
        public void Post(BookDTO value)
        {
            Book model = new Book()
            {
                Name = value.Name,
                Popularity = value.Popularity,
                PublicationYear = value.PublicationYear
            };
            IBookRepository.Create(model);
            for (int i = 0; i < value.WriterId.Count; i++)
            {
                BookWriter BookWriter = new BookWriter()
                {
                    BookId = model.Id,
                    WriterId = value.WriterId[i]
                };
                IBookWriterRepository.Create(BookWriter);
            }

            for (int i = 0; i < value.LibraryId.Count; i++)
            {
                BookLibrary BookLibrary = new BookLibrary()
                {
                    BookId = model.Id,
                    LibraryId = value.LibraryId[i]
                };
                IBookLibraryRepository.Create(BookLibrary);
            }

            for (int i = 0; i < value.PublisherId.Count; i++)
            {
                BookPublisher BookPublisher = new BookPublisher()
                {
                    BookId = model.Id,
                    PublisherId = value.PublisherId[i]
                };
                IBookPublisherRepository.Create(BookPublisher);
            }

        }

        // PUT: api/Album/5
        [HttpPut("{id}")]
        public void Put(int id, BookDTO value)
        {
            Book model = IBookRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }
            if (value.Popularity != null)
            {
                model.Popularity = value.Popularity;
            }
            if (value.PublicationYear != 0)
            {
                model.PublicationYear = value.PublicationYear;
            }

            IBookRepository.Update(model);

            if (value.WriterId != null)
            {
                IEnumerable<BookWriter> MyBookWriters = IBookWriterRepository.GetAll().Where(x => x.BookId == id);
                foreach (BookWriter MyBookWriter in MyBookWriters)
                    IBookWriterRepository.Delete(MyBookWriter);
                for (int i = 0; i < value.WriterId.Count; i++)
                {
                    BookWriter BookWriter = new BookWriter()
                    {
                        BookId = model.Id,
                        WriterId = value.WriterId[i]
                    };
                    IBookWriterRepository.Create(BookWriter);
                }

            }
            if (value.LibraryId != null)
            {
                IEnumerable<BookLibrary> MyLibraryBooks = IBookLibraryRepository.GetAll().Where(x => x.BookId == id);
                foreach (BookLibrary MyLibraryBook in MyLibraryBooks)
                    IBookLibraryRepository.Delete(MyLibraryBook);
                for (int i = 0; i < value.LibraryId.Count; i++)
                {
                    BookLibrary BookLibrary = new BookLibrary()
                    {
                        BookId = model.Id,
                        LibraryId = value.LibraryId[i]
                    };
                    IBookLibraryRepository.Create(BookLibrary);
                }

            }
            if (value.PublisherId != null)
            {
                IEnumerable<BookPublisher> MyPublisherBooks = IBookPublisherRepository.GetAll().Where(x => x.BookId == id);
                foreach (BookPublisher MyPublisherBook in MyPublisherBooks)
                    IBookPublisherRepository.Delete(MyPublisherBook);
                for (int i = 0; i < value.PublisherId.Count; i++)
                {
                    BookPublisher BookPublisher = new BookPublisher()
                    {
                        BookId = model.Id,
                        PublisherId = value.PublisherId[i]
                    };
                    IBookPublisherRepository.Create(BookPublisher);
                }

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Book Delete(int id)
        {
            Book book = IBookRepository.Get(id);
            return IBookRepository.Delete(book);
        }
    }
}
