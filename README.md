# bannerflow-backend
Used Visual Studio Code to debug. REST API that can deal with Model consisting of banner: id (int), Html (text), Created (DATETIME), Modified (DATETIME).

URL is set up:
{whatever localhost}/api/banner -> main page, will display all the banners as list
{whatever localhost}/api/banner/{banner id} -> will display specific banner associated with that id
{whatever localhost}/api/banner/content/{banner id} -> will display a page that has the content of html within banner model

Complies CRUD (has get/set[POST]/update[PUT]/delete methods)
