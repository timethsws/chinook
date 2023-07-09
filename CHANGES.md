## Changes done

* Create two services named ```ArtistService``` and ```PlaylistService``` and move business logic there.
* Enable auto generation of entity keys, changed ```ValueGeneratedNever()``` from ```ValueGeneratedOnAdd()``` in ```ChinookContext``` for primary keys.
* Added ```NavStateContainer``` to programatically trigger Navbar re-renders

### Changes which were identified but weren't completed

* Error message propergation from Service layer to View Layer
* Some of the component/logic which were duplicated can be extracted and reused 
  * track table item, 
  * add/remove favourites


### Explenations
#### Task 1 - Move data retrieval methods to separate class / classes (use dependency injection)

Created two services to handle artist related functionalities and playlist related functionalities named artistService and PlaylistService and moved all the business logic there instead of having those in the razor pages. So that any changes to the functionalities can be done within the service layer and it will be reflected in all the places where the functionality has been used. There are improvements that can be done for logging and error handling and error propergation to the view layer which is not coverd yet

#### Task 2 - Favorite / unfavorite tracks. An automatic playlist should be created named "My favorite tracks"

Wrote seperate logic to handle creation of a playlist named "My favorite tracks" whenever a user favourites a track, there are improvements to be done, like make sure the user cannot create similar named playlists, and the playlist view needs to be modified to handle the favourits playlist with special functionalities

#### Task 3 - The user's playlists should be listed in the left navbar. If a playlist is added (or modified), this should reflect in the left navbar (NavMenu.razor). Preferrably, the left menu should be refreshed without a full page reload.

This was a handled using a State Container to reduce the time spent on the implementation, and the NavStateContainer is written in a way that it can be user to update the nav bar component from anywhere.

#### Task 4 - Add tracks to a playlist (existing or new one). The dialog is already created but not yet finished.
New data bindings and a model was created with additional functionality added to the Playlist service to support adding tracks to a playlist

#### Task 5 - Search for artist name

Simpler serach was implemented with a input binding to search the artist list with by the artist name