module.exports = async function (context, req) {

  var bookmark = context.bindings.bookmark

  if (boookmark) {
    context.res = {
      body: {
        "url": bookmark.url
      },
      headers: {
        'Content-Type': 'application/json'
      }
    }

  }
  else {
    context.res = {
      status: 404,
      body: "No bookmarks found",
      headers: {
        'Content-Type': 'application/json'
      }
    }
  }
}