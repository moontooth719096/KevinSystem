/// <binding BeforeBuild='copy-libs' />
"use strict";

var _ = require("lodash"),
    gulp = require("gulp"),
    rimraf = require("rimraf"),
    uglify = require("gulp-uglify"),
    cssmin = require("gulp-cssmin"),
    rename = require("gulp-rename");

var libs = [
    { name: "bootstrap", value: "./node_modules/bootstrap/dist/**/*.*" },
    { name: "jquery", value: "./node_modules/jquery/dist/**/*.*" },
    { name: "jquery-validation", value: "./node_modules/jquery-validation/dist/**/*.*" },
    { name: "jquery-validation-unobtrusive", value: "./node_modules/jquery-validation-unobtrusive/*.*" }
];

gulp.task("copy-libs", function () {
    libs.forEach(function (item) {
        gulp.src(item.value)
            .pipe(gulp.dest("./wwwroot/lib/" + item.name + "/dist"));
    });
});

gulp.task("clean:libs", function (cb) {
    rimraf("./wwwroot/lib/", cb);
});

gulp.task("copy-asset", ["clean:libs", "copy-libs"]);