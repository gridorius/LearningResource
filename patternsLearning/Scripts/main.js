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
                <h1 v-if='!src1 && !src2 && name'>{{name}}</h1>
                <div><slot></slot></div>
            </section>
        </div>
    `,
    props: ['src1', 'src2', 'name'],
});

Vue.component('m-code', {
    template: `
        <div class='code'><slot></slot></div>
    `
});

Vue.component('m-article', {
    template: `
        <div class='article'>
            <v-sec :name='art.art_name'>{{art.art_description}}</v-sec>
            <v-sec :src2='bp.base_part_pic' v-for='bp in art.base_part'>
                <h1>{{bp.base_part_name}}</h1>
                <div v-html='bp.base_part_description'></div>
                <div>{{bp.base_part_info}}</div>
            </v-sec>
            <v-sec :src2='sp.sample_part_pic' v-for='sp in art.sample_part'>
                <h1>{{sp.sample_part_name}}</h1>
                <div>{{sp.sample_part_description}}</div>
                <div>{{sp.sample_part_info}}</div>
                <h2>Пример кода</h2>
                <div v-html="sp.sample_part_code"></div>
                <a :href='sp.sample_part_gitref'>GitHub</a>
            </v-sec>
        </div>
    `,
    props: ['art'],
    created() {
        alert(this.art.sample_part[0].sample_part_code);
    }
});