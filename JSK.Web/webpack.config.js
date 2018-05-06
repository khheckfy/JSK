const path = require('path');

const bundleFolder = "./wwwroot/assets/";
const srcFolder = "./App/"

module.exports = {
    mode: 'development',
    entry: srcFolder + 'index.ts',
    module: {
        rules: [
            {
                test: /\.ts?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            },
            {
                test: /\.css$/,
                loaders: ['style-loader', 'css-loader']
            },
            { test: /\.woff(2)?(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url-loader" },
            { test: /\.(ttf|eot|svg)(\?v=[0-9]\.[0-9]\.[0-9])?$/, loader: "url-loader" }
        ]
    },
    devtool: "source-map",
    resolve: {
        extensions: ['.js', '.ts', '.json'],
    },
    output: {
        filename: "bundle.js",
        publicPath: 'assets/',
        path: path.resolve(__dirname, bundleFolder),
        libraryTarget: "var",
        library: "TL"
    },
};