using ForumMini.Entities;
using ForumMini.InMemoryRepositories;
using ForumMini.RepositoryContracts;
using CLI.UI;

Console.WriteLine("ForumMini CLI Application");
Console.WriteLine("========================");

IUserRepository userRepo = new UserInMemoryRepository();
IPostRepository postRepo = new PostInMemoryRepository();
ICommentRepository commentRepo = new CommentInMemoryRepository();

var cliApp = new CliApp(userRepo, postRepo, commentRepo);
await cliApp.StartAsync();