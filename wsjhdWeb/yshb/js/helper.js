/*
摇一摇模块
*/
Shake = {};
Shake.config = {
    SHAKE_THRESHOLD: 2000,
    shakelock: 1
};
Shake.Init = function (CallBack) {
    if (window.DeviceMotionEvent) {
        var SHAKE_THRESHOLD = this.config.SHAKE_THRESHOLD;
        var lastUpdate = 0;
        var x, y, z, last_x, last_y, last_z;
        window.addEventListener('devicemotion', function (eventData) {
            // Grab the acceleration including gravity from the results
            var shakelock = Shake.config.shakelock;
            var acceleration = eventData.accelerationIncludingGravity;
            var curTime = new Date().getTime();
            if ((curTime - lastUpdate) > 100) {
                var diffTime = (curTime - lastUpdate);
                lastUpdate = curTime;
                x = acceleration.x;
                y = acceleration.y;
                z = acceleration.z;
                var acc = (Math.abs(x - last_x) + Math.abs(y - last_y) + Math.abs(z - last_z)) / diffTime * 10000;
                if (acc > SHAKE_THRESHOLD && shakelock == 0) {
                    Shake.config.shakelock = 1;
                    CallBack();
                }
                last_x = x;
                last_y = y;
                last_z = z;
            }
        }, false);
    }
}