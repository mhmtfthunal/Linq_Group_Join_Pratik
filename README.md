# LINQ Group Join Pratik 

Bu repo, **C# LINQ** kullanarak `Students` (öğrenciler) ve `Classes` (sınıflar) arasında **group join** işlemini gösterir. Amaç, her sınıfın altında o sınıfa ait öğrencilerin listelenmesini sağlamaktır.

---

## 📋 Tablolar

### Öğrenciler (Students)

| StudentId | StudentName | ClassId |
| --------- | ----------- | ------- |
| 1         | Ali         | 1       |
| 2         | Ayşe        | 2       |
| 3         | Mehmet      | 1       |
| 4         | Fatma       | 3       |
| 5         | Ahmet       | 2       |

### Sınıflar (Classes)

| ClassId | ClassName |
| ------- | --------- |
| 1       | Matematik |
| 2       | Türkçe    |
| 3       | Kimya     |

---

## 🧱 Model Sınıfları

```csharp
public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public int ClassId { get; set; }
}

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
}
```

---

## 🔢 Örnek Veri

```csharp
var students = new List<Student>
{
    new Student { StudentId = 1, StudentName = "Ali",    ClassId = 1 },
    new Student { StudentId = 2, StudentName = "Ayşe",   ClassId = 2 },
    new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
    new Student { StudentId = 4, StudentName = "Fatma",  ClassId = 3 },
    new Student { StudentId = 5, StudentName = "Ahmet",  ClassId = 2 }
};

var classes = new List<Class>
{
    new Class { ClassId = 1, ClassName = "Matematik" },
    new Class { ClassId = 2, ClassName = "Türkçe" },
    new Class { ClassId = 3, ClassName = "Kimya" }
};
```

---

## 🔍 LINQ Group Join

### 1) Sorgu Sözdizimi (Query Syntax)

```csharp
var result =
    from c in classes
    join s in students on c.ClassId equals s.ClassId into studentGroup
    select new
    {
        ClassName = c.ClassName,
        Students = studentGroup
    };

foreach (var group in result)
{
    Console.WriteLine($"Sınıf: {group.ClassName}");
    foreach (var student in group.Students)
    {
        Console.WriteLine($"  - {student.StudentName}");
    }
    Console.WriteLine();
}
```

### 2) Yöntem Sözdizimi (Method Syntax)

```csharp
var methodResult = classes.GroupJoin(
    students,
    c => c.ClassId,
    s => s.ClassId,
    (c, studs) => new { c.ClassName, Students = studs }
);

foreach (var group in methodResult)
{
    Console.WriteLine($"Sınıf: {group.ClassName}");
    foreach (var student in group.Students)
    {
        Console.WriteLine($"  - {student.StudentName}");
    }
    Console.WriteLine();
}
```

---

## 🖥️ Program (Tam Çalışır Konsol Uygulaması)

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGroupJoinExample
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public int ClassId { get; set; }
    }

    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali",    ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Ayşe",   ClassId = 2 },
                new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
                new Student { StudentId = 4, StudentName = "Fatma",  ClassId = 3 },
                new Student { StudentId = 5, StudentName = "Ahmet",  ClassId = 2 }
            };

            var classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Türkçe" },
                new Class { ClassId = 3, ClassName = "Kimya" }
            };

            // Query Syntax
            var result =
                from c in classes
                join s in students on c.ClassId equals s.ClassId into studentGroup
                select new { c.ClassName, Students = studentGroup };

            Console.WriteLine("=== GROUP JOIN (Query Syntax) ===\n");
            foreach (var group in result)
            {
                Console.WriteLine($"Sınıf: {group.ClassName}");
                foreach (var student in group.Students)
                    Console.WriteLine($"  - {student.StudentName}");
                Console.WriteLine();
            }

            // Method Syntax (alternatif)
            var methodResult = classes.GroupJoin(
                students,
                c => c.ClassId,
                s => s.ClassId,
                (c, studs) => new { c.ClassName, Students = studs }
            );

            Console.WriteLine("=== GROUP JOIN (Method Syntax) ===\n");
            foreach (var group in methodResult)
            {
                Console.WriteLine($"Sınıf: {group.ClassName}");
                foreach (var student in group.Students)
                    Console.WriteLine($"  - {student.StudentName}");
                Console.WriteLine();
            }
        }
    }
}
```

---

## 🧪 Beklenen Çıktı

```
Sınıf: Matematik
  - Ali
  - Mehmet

Sınıf: Türkçe
  - Ayşe
  - Ahmet

Sınıf: Kimya
  - Fatma
```

---

## 🚀 Çalıştırma Adımları

1. Yeni bir **Console App** (ör. .NET 6+) oluşturun.
2. Yukarıdaki **Tam Program** kodunu `Program.cs` dosyasına kopyalayın.
3. Terminal/PowerShell’de proje klasöründe çalıştırın:

   ```bash
   dotnet run
   ```
4. Konsolda sınıflar ve öğrenciler listelenmiş olarak görünecektir.

---

## 🎯 Öğrenme Hedefleri

* `group join` ile iki koleksiyonun nasıl ilişkilendirileceğini öğrenmek.
* Query ve Method syntax farklarını görmek.
* Boş sınıf senaryoları için `Any()` ile kontrol ekleyebilmeyi kavramak (geliştirme ödevi).

---

## 🧩 Ek Alıştırmalar

* **Boş sınıf** ekleyin (ör. `ClassId=4, ClassName="Fizik"`) ve çıktıda "(Öğrenci yok)" yazdırın.
* Öğrencileri **alfabetik** sırala (`OrderBy`).
* Çıktıyı `ClassName`e göre sırala (`OrderBy`).

> İpucu: `group.Students.Any()` ile boş grup kontrolü yapabilirsiniz.
