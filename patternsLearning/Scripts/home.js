Vue.component('double-parallax', {
    template: `
        <div class='parallax'>
            <div class='p-active' ref='img'>
                <img :src='src2' :style="{transform:'translateY('+(y/2-100)+'px)'}"></img>
                <img v-if='src1' :src='src1' :style="{transform:'translateY('+(y/3)+'px)'}"></img>
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
            <double-parallax v-if='src1 || src2' :src1='src1' :src2='src2'><slot></slot></double-parallax>
            <section>
                <h1><slot v-if='!src1 && !src2'></slot></h1>
                <div class='content'>{{description}}</div>
            </section>
        </div>
    `,
    props: ['src1', 'src2', 'description'],

});

let app = new Vue({
    el: '.main',
    data: {
        briefDescriptions: [],
    },
    methods: {
        setBriefDescription(arr) {
            this.briefDescriptions = arr;
        }
    }
});

fetch('/Home/BriefDescription').then(r => r.text()).then(t => JSON.parse(t.replace(/&quot;/g, '\"')).art).then(app.setBriefDescription);
