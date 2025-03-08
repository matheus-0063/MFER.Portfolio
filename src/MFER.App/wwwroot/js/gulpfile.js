const gulp = require('gulp');
const concat = require('gulp-concat');
const cssmin = require('gulp-cssmin');
const uglify = require('gulp-uglify');

// Caminhos dos arquivos CSS e JS
const cssFiles = [
    'wwwroot/lib/bootstrap/css/bootstrap.css',
    'wwwroot/css/site.css'
];

const jsFiles = [
    'wwwroot/js/site.js',
    'wwwroot/js/cep.js'
];

// Tarefa para minificar e fazer bundling do CSS
gulp.task('css', function() {
    return gulp.src(cssFiles)
        .pipe(concat('site.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest('wwwroot/css'));
});

// Tarefa para minificar e fazer bundling do JS
gulp.task('js', function() {
    return gulp.src(jsFiles)
        .pipe(concat('site.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('wwwroot/js'));
});

// Tarefa padrão para rodar ambos (CSS + JS)
gulp.task('default', gulp.parallel('css', 'js'));