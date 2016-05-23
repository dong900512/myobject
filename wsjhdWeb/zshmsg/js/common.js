Array.prototype.objCount = function (c) { return c; }

String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g, function (m, i) {
        return args[i];
    });
}


String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }

    return str;
}

String.formatArgs = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    var args = arguments[1];
    for (var i = 0; i < args.length; i++) {
        var re = new RegExp('\\{' + i + '\\}', 'gm');
        str = str.replace(re, args[i]);
    }

    return str;
}