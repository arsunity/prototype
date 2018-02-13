const path = require('path');
const webpack = require('webpack');

module.exports = {
    entry: {
        'app': './client/main.ts'
    },
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'), // путь к каталогу выходных файлов
        publicPath: '/dist/',     
        filename: "[name].js"       // название создаваемого файла
    },
    resolve: {
        extensions: ['.ts', '.js']
    },
    module: {
        rules: [   //загрузчик для ts
            { test: /\.ts$/, include: /client/, use: ['awesome-typescript-loader?silent=true', 'angular2-template-loader'] },
            { test: /\.html$/, use: 'html-loader?minimize=false' }
        ]
    },
    plugins: [
        new webpack.ContextReplacementPlugin(
            /angular(\\|\/)core/,
            path.resolve(__dirname, 'client'), // каталог с исходными файлами
            {} // карта маршрутов
        ),
        new webpack.optimize.CommonsChunkPlugin({
            name: ['app']
        })
    ]
}
