const path = require("path"),
  webpack = require("webpack"),
  AssetsPlugin = require("assets-webpack-plugin"),
  UglifyJsPlugin = require("uglifyjs-webpack-plugin");

const isProd = process.env.NODE_ENV === "production";

const devPlugins = [
  new AssetsPlugin({
    prettyPrint: true,
    filename: "assets.json",
    path: path.resolve(__dirname, "build")
  }),
  new webpack.DefinePlugin({
    __ENV__: JSON.stringify(process.env.NODE_ENV || "development")
  })
];

const prodPlugins = [
  new UglifyJsPlugin({
    cache: true,
    parallel: true,
    sourceMap: true
  })
];

const pluginList = isProd ? [...devPlugins, ...prodPlugins] : devPlugins;

module.exports = {
  mode: "production",
  context: __dirname,
  devtool: "",
  entry: ["babel-polyfill", "./app.js"],
  output: {
    filename: "[name].js",
    path: path.resolve(__dirname, "build"),
    publicPath: "build"
  },
  plugins: pluginList,
  optimization: {
    splitChunks: {
      cacheGroups: {
        vendor: {
          test: /[\\/]node_modules[\\/](react|react-dom)[\\/]/,
          name: "vendor",
          chunks: "all"
        }
      }
    }
  },
  devtool: isProd ? "" : "inline-source-map",
  module: {
    rules: [
      {
        test: /\.css$/,
        use: [{ loader: "style-loader" }, { loader: "css-loader" }]
      },
      {
        test: /\.m?js$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader"
        }
      },
      {
        test: /\.(pdf|jpg|png|gif|svg|ico)$/,
        use: [
          {
            loader: "url-loader"
          }
        ]
      }
    ]
  }
};
