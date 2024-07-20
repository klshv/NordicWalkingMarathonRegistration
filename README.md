# NordicWalkingMarathonRegistration

NordicWalkingMarathonRegistration is a web application for registering participants in a Nordic walking marathon. The registration form collects participant details, performs preliminary validation, and saves the data in both JSON format and a relational database.

## Features

- Registration form with the following fields:
  - Participant Name
  - Gender
  - Age at the time of registration
  - Sports experience (in years)
  - City of residence
- Form validation:
  - No empty submissions allowed
  - Age and sports experience must be numerical values
  - Gender must be selected from a predefined list
  - City must be entered in Cyrillic characters
- JSON file generation containing the entered data
- Data storage in a relational database
