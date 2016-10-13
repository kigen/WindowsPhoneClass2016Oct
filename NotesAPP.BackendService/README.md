# API Documents
This is a simple API document for a simple note taking mobile application backend service.

## API End points
### Post Notes.
 - Path: /notes
 - Method: POST
 - ContentType: application/json
 - Request Payload example:
 ```json
    {
        "Title":"First Note",
        "Content" : "To do something about this task.",
        "Category":"Tasks",
        "Latitude": -1.2,
        "Longitude": 36.0,
        "User": "{your student numbers separated by - eg 12447-85888-85858}"
    }
    ```

- Response example:
    ```json
    {
      "NoteID":1,
      "Title":"First Note",
      "Content" : "To do something about this task.",
      "Category":"Tasks",
      "Latitude": -1.2,
      "Longitude": 36.0,
      "User":"1234-5678-9876"
    }
    ```

###Fetch your notes:
Fetch notes from the service.
- Path:
  * All Notes: /notes/
  * Your Notes: /notes/?user={student numbers}
- Method: GET
- ContentType: application/json
- Response Payload example:

```json
   [{
       "NoteID":1,
       "Title":"First Note",
       "Content" : "To do something about this task.",
       "Category":"Tasks",
       "Latitude": -1.2,
       "Longitude": 36.0,
       "User":"1234-5678-9876"
   },{
      "NoteID":2,
       "Title":"Second Note",
       "Content" : "To do something about this meeting.",
       "Category":"Meeting",
       "Latitude": -1.2,
       "Longitude": 36.0,
       "User":"1234-5678-9876"
   },{
       "NoteID":3,
       "Title":"Third Note",
       "Content" : "This is a random note.",
       "Category": "Others",
       "Latitude": -1.2,
       "Longitude": 36.0,
       "User":"1234-5678-9876"
   }]
   ```
