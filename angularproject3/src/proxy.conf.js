const PROXY_CONFIG = [
  {
    context: [
      "/api/v1/Directors",
      "/api/v1/Movies",
    ],
    target: "https://localhost:7118",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
