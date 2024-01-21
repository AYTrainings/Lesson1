using System.Runtime.Loader;

// Путь к вашей DLL
var libraryPath = @"D:\\NewRepository\\Lesson1\\MyLibrary\\bin\\Debug\\net8.0\\MyLibrary.dll";

// Создаём контекст загрузки библиотеки
var assemblyLoadContext = new AssemblyLoadContext(null, true);

// Загружаем библиотеку из файла
var loadedAssembly = assemblyLoadContext.LoadFromAssemblyPath(libraryPath);

// Получаем нужный нам класс из библиотеки 
var displayMessageType = loadedAssembly.GetType("MyLibrary.MyClass");

// Создаём экземпляр этого класса
var displayMessageInstance = Activator.CreateInstance(displayMessageType);

// Вызываем нужный нам метод
displayMessageType.GetMethod("GetGreetingMessage")?.Invoke(displayMessageInstance, null);

// Выгружаем загруженные ранее библиотеки
assemblyLoadContext.Unload();