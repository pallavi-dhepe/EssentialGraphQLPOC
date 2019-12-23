

//*************** data fetch query ex. 1 *********************//
//get all projects with specified properties

{
  projects {
    projectId,
    projectName,
    persons {
      personId,
      personName
    }
  }
}

//*************** data fetch query ex. 2 *********************//
//get all projects with pople in the project with manager = 5 role
{
  projects {
    projectId,
    projectName,
    persons(roleid:5){
      personId,
      personName
    }
  }
}

//****************** data fetch query ex. 3 *****************//
//get project with id 1 and get manager of it
{
  project(projectid:1) {
    projectId,
    projectName,
    persons(roleid:5){
      personId,
      personName
    }
  }
}

//get project with id 1 and get all people in the project
{
  project(projectid:1) {
    projectId,
    projectName,
    persons{
      personId,
      personName
    }
  }
}