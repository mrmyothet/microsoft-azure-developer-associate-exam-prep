module.exports = async function (context, req) {
  context.log('JavaScript HTTP trigger function processed a request.');

  const name = (req.query.name || (req.body && req.body.name));
  const responseMessage = name
    ? "Hello, " + name + ". This HTTP triggered function executed successfully."
    : "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response.";

  var bookmark = context.bindings.bookmark;
  if (bookmark) {
    context.res = {
      status: 422,
      body: "Bookmark already exists.",
      headers: {
        'Content-Type': 'application/json'
      }
    };
  }
  else {

    // Create a JSON string of our bookmark.
    var bookmarkString = JSON.stringify({
      id: req.body.id,
      url: req.body.url
    });

    // Write this bookmark to our database.
    context.bindings.newbookmark = bookmarkString;

    // Push this bookmark onto our queue for further processing.
    context.bindings.newmessage = bookmarkString;

    // Tell the user all is well.
    context.res = {
      status: 200,
      body: "bookmark added!",
      headers: {
        'Content-Type': 'application/json'
      }
    };
  }
  context.done();
}