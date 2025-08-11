## **README.md**

# **University Search Engine API**

### **Course**: CSC322 – A Modern Programming Language

### **Lecturer**: Dr. V. T. Odumuyiwa

### **Project 2** – Design and Development of a Search Engine

### **Language**: C# (.NET 8)

---

## **Overview**

This project is a **Search Engine API** implemented in **C#** and **.NET**. It is designed for integration into the University’s website and intranet to provide fast, relevant, and ranked search results from a document repository.

The API supports multiple file formats, uses efficient indexing and ranking algorithms, and delivers query responses in ≤ 0.01 seconds. A demonstration **Graphical User Interface (GUI)** built with WinForms/WPF/ASP.NET (depending on your implementation) is included to showcase its functionality.

---

## **Key Features**

* **Supported Formats**: `pdf`, `doc`, `docx`, `ppt`, `pptx`, `xls`, `xlsx`, `txt`, `html`, `xml`
* **High Performance**: ≤ 0.01 seconds query response time
* **Autocomplete Suggestions** for queries
* **Efficient Indexing** with ≤ 2 hours delay for new documents
* **Stop-word Removal** for improved accuracy
* **Relevance Ranking** using frequency and semantic matching
* **API-First Design** for easy integration into any system
* **GUI Demonstration** for user interaction and testing

---

## **Architecture**

The search engine is structured into **four core modules**:

1. **Indexer**

   * Extracts keywords from documents
   * Removes stop words
   * Computes keyword frequency
   * Stores data in an **inverted index**

2. **Query Parser**

   * Processes and normalizes search queries
   * Converts them into a structured form for matching

3. **Matching & Ranking Engine**

   * Retrieves documents based on keyword matches
   * Ranks results by relevance score

4. **Results Interface**

   * Displays search results in the GUI
   * Allows users to view document contents

---

## **Technologies Used**

* **Language**: C#
* **Framework**: .NET 8 (or .NET 6 if targeting LTS)
* **Libraries**:

  * `iText7` – PDF Parsing
  * `DocumentFormat.OpenXml` – DOCX, PPTX, XLSX parsing
  * `HtmlAgilityPack` – HTML/XML parsing
  * `System.Text.Json` – Index storage
* **GUI**: WinForms / WPF / ASP.NET Razor Pages (depending on project choice)
* **Testing**: xUnit or NUnit

---

## **Installation & Setup**

```bash
# Clone the repository
git clone https://github.com/<your-team>/university-search-engine-csharp.git
cd university-search-engine-csharp

# Restore dependencies
dotnet restore

# Build the project
dotnet build
```

---

## **Running the API**

```bash
dotnet run --project SearchEngine.Api
```

API available at: `https://localhost:5001`

---

## **Running the GUI**

Open the GUI project in Visual Studio and press **F5** to run.
Example GUI components:

* Search bar with autocomplete
* Search results list
* Document viewer

---

## **API Endpoints**

| Method | Endpoint           | Description           |
| ------ | ------------------ | --------------------- |
| POST   | `/index`           | Index a new document  |
| GET    | `/search?q=`       | Search for documents  |
| GET    | `/autocomplete?q=` | Get query suggestions |

---

## **Team Members**

* **\[Name 1]** – Backend Development & Indexing
* **\[Name 2]** – GUI Development
* **\[Name 3]** – Query Parsing & Ranking Logic
* **\[Name 4]** – Testing & Documentation

---

## **Acknowledgements**

* Department of Computer Science, \[University Name]
* Dr. V. T. Odumuyiwa for project guidance

---

### **Project Description for Submission**

**Title**: Design and Development of a Search Engine API for the University Website and Intranet in C#

**Abstract**:
This project implements a **Search Engine API** in **C# and .NET**, designed for fast and efficient information retrieval from academic and administrative document repositories. It uses an inverted index for efficient storage and retrieval, applies stop-word removal, and ranks results using keyword frequency and semantic matching. A GUI demonstration allows interactive testing of the API.

**Objectives**:

* Implement a reusable, API-based search engine in C#
* Apply **Abstract Data Type (ADT)** concepts for search indexing
* Integrate common design patterns such as **Factory** and **Singleton**
* Develop a query parser using efficient parsing techniques
* Encourage collaborative software engineering

**Methodology**:

* **Indexing**: Extract keywords, remove stop words, compute frequency, store in inverted index.
* **Query Parsing**: Normalize and tokenize queries for processing.
* **Matching & Ranking**: Retrieve and rank relevant documents using scoring algorithms.
* **GUI**: Demonstrate API functionality with a user-friendly interface.

**Expected Outcome**:
A robust, fast, and integrable search engine API written in **C#**, meeting the performance and design specifications provided by the Department of Computer Science.
