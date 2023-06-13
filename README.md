# Path Sharp
PathSharp is a C# library that provides bindings for the UiPath Orchestrator Web API. It allows you to interact with the UiPath Orchestrator and perform various operations such as authorizing the client, starting jobs, getting job details, and more.

### Installation
To use PathSharp in your C# project, you can install it via NuGet Package Manager. Run the following command in the NuGet Package Manager Console:

```Install-Package PathSharp```

### Usage

To use the `PathClient` class, follow these steps:

```csharp
// Create an instance of the PathClient class
string baseAddress = RequestAddress.Base.Default;
string orchestratorAddress = "/{organization_name}/{tenant-name}/orchestrator_";
int organizationUnit = "(some numbers)";

using(PathClient client = new PathClient(baseAddress, orchestratorAddress, organizationUnit))
{
    // Authorize the client
    string clientSecret = "your_client_secret"; // A bunch of random characters
    string clientId = "your_client_id"; // Also known as "App ID", is a UUID
    List<string> scope = PathClient.DefaultScope;

    await client.AuthorizeAsync(clientSecret, clientId, scope);

    // Interact with the API using the client
    StartJobBody jobBody = new StartJobBody { /* provide necessary parameters */ };   
    List<Job>? startedJobs = await client.StartJobsAsync(jobBody); // start a job

    List<Job>? jobs = await client.GetJobsAsync(); // get all jobs

    long jobId = 12345;
    Job? job = await client.GetJobAsync(jobId); // get a specific job
}
```

### Notes
- The `PathClient` class implements the `IDisposable` interface, so it is recommended to use it in a `using` statement. This is because it uses the `HttpClient` class internally, which implements `IDisposable`.
- It is recommended to use a single instance of the `PathClient` class in your application since `HttpClient` is designed to be reused.
- The `PathClient` needs to be authorized before it can call endpoints that require it (I think that's all of them)

### Exceptions (more usage examples)
```csharp
try
{
    List<Job>? startedJobs = await client.StartJobsAsync(jobBody);
}
catch(PathException exception) // will contain the error message from the API
{
    StartJobValidationResult? validation = await client ValidateDynamicJobAsync(jobBody);

    if(validation == null)
    {
        Console.WriteLine("Validation and starting of job failed with exception:");
        Console.WriteLine(exception.Message);
    }
    else
    {
        if(validation.IsValid)
        {
            Console.WriteLine("Validation of job succeeded, but starting of job failed.");
            Console.WriteLine("Starting of job failed with message: {exception.Message}");
        }
        else
        {
            List<string> errors = validation.Errors;
            string errorString = string.Join("\n", validation.Errors);

            Console.WriteLine($"Validation of job failed, error count: {errorString}");
        }
    }
}
```

### What's the point?
To help people who want to use the UiPath web api from code but don't want to deal with the hassle of writing the code to do so. Also, please note that I am in no way affiliated with UiPath, I am just doing this to help people and UiPath create a better world together. I hope this library will help people who want to use UiPath's services and that it will help UiPath by making their services more accessible.

I think information and knowledge is made to be shared and that's why I'm sharing this library with you. I hope you will find it useful and that it will help you in your endeavors. If you want to contribute to this project, please feel free to do so. I will be happy to accept any contributions that will make this library better and more useful for everyone.

You can create an issue or a pull request if you want to contribute.

### License
This project is licensed under the MIT license. See the LICENSE file for more info.

### Contributing

#### Tests
To run the tests you should edit the TestSecrets.json file that will be created in the same directory as the built assembly. The path to the test secrets file is probably PathSharpTests/bin/Debug/net6.0/TestSecrets.json.

The orchestrator url should not start nor end with a "/".

The OrganizationUnitId in test secrets should be the id of a folder that contains jobs. Folders can be gotten with the GetFoldersAsync() method in client.