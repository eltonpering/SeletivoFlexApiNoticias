### News API Solution

The Postman application for testing was used.

Here are the parameterizations as an example:

#### ------ News Registration ------

Type request: POST

Url: (https: // localhost: 44331 / api / values ​​/ Register)

JSon:
      `{
        "author_id": 1,
        "Title": "Title Tests",
        "Text": "New text"
      } `
      
      
#### ------ News Release ------

Type request: POST

Url: (https: // localhost: 44331 / api / values ​​/ Edit)

JSon:
      `{
        "author_id": 1,
        "Title": "Title Tests 2",
        "Text": "Text noticia 2"
      } `
      
      
#### ------ News Exclusion ------

Type request: DELETE

Url: (https: // localhost: 44331 / api / values ​​/ Delete)

JSon:
    `{
"id_noticia": 1
    } `
    
#### ------ List All News ------

Request Type: GET

Url: (https: // localhost: 44331 / api / values ​​/ List)


#### ------ Search the News by text in the fields Author, Title and Text ------

Request Type: GET

Url: (https: // localhost: 44331 / api / values ​​/ Search)

JSon:
    `{
"Text": "New text"
    } `
