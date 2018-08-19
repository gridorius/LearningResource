Vue.component('double-parallax', {
    template: `
        <div class='parallax'>
            <div class='p-active' ref='img'>
                <div :style="{backgroundImage:'url('+src2+')',transform:'translateY('+(y/2-100)+'px)'}"></div>
                <div :style="{backgroundImage:'url('+src1+')',transform:'translateY('+(y/3)+'px)'}"></div>
            </div>
            <div class='p-passive'><slot></slot></div>
        </div>
    `,
    props: ['src1', 'src2'],
    data() {
        return {
            y: 0,
        };
    },
    created() {
        window.addEventListener('scroll', (e) => {
            this.y = -this.$refs.img.getBoundingClientRect().y;
        });
    }

});

Vue.component('v-sec', {
    template: `
        <div>
            <double-parallax v-if='src1 || src2' :src1='src1' :src2='src2'>{{name}}</double-parallax>
            <section>
                <h1 v-if='!src1 && !src2'>{{name}}</h1>
                <div class='content'><slot></slot></div>
            </section>
        </div>
    `,
    props: ['src1', 'src2', 'name'],

});