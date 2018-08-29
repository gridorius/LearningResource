Vue.component('double-parallax', {
    template: `
        <div class='parallax' :style='{height:height}' ref='cont'>
            <div class='p-active' ref='img'>
                <div :style="{backgroundImage:'url('+src2+')',transform:'translateY('+(y/2-100)+'px)'}"></div>
                <div :style="{backgroundImage:'url('+src1+')',transform:'translateY('+(y/3)+'px)'}"></div>
            </div>
            <div class='p-passive' :style="{lineHeight:height || '60vh'}"><slot></slot></div>
        </div>
    `,
    props: ['src1', 'src2','height'],
    data() {
        return {
            y: 0,
            lh:0,
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
            <double-parallax v-if='src1 || src2' :height='parallaxHeight' :src1='src1' :src2='src2'>{{name}}</double-parallax>
            <section>
                <h1 v-if='!src1 && !src2 && name'>{{name}}</h1>
                <div><slot></slot></div>
                <m-content v-if='a'><a class='detailed'  :href='a'>{{name}}</a></m-content>
            </section>
        </div>
    `,
    props: ['src1', 'src2', 'name','a','parallaxHeight'],
});

Vue.component('m-content', {
    template: `
        <div class='content'><slot></slot></div>
    `
});

Vue.component('m-article', {
    template: `
        <div class='article'>
            <div class='close' @click='$root.article = false'>✖</div>
            <v-sec :parallax-height="'100vh'"  :src1='art.art_pic' :name='art.art_name'>
                <m-content>
                    {{art.art_description}}
                    <h2>Мотивация</h2>
                    {{art.art_motivation}}
               </m-content>
            </v-sec>
            <v-sec>
                <div v-for='bp in art.base_part'>
                    <m-content>
                        <h2>{{bp.base_part_name}}</h2>
                        <div v-html='bp.base_part_description'></div>
                        <div>{{bp.base_part_info}}</div>
                        <center>
                            <h2>UML</h2>
                            <img :src='bp.base_part_pic'/>
                        </center>
                    </m-content>
                </div>                                
                <div v-for='sp in art.sample_part'>
                    <m-content>
                        <h2>{{sp.sample_part_name}}</h2>
                        <div>{{sp.sample_part_description}}</div>
                        <div>{{sp.sample_part_info}}</div>
                        <center>
                            <h2>UML</h2>
                            <img :src='sp.sample_part_pic'/>
                        </center>
                        <h2>Пример кода</h2>
                        <div class='code' v-html='sp.sample_part_code'></div><br>
                        <h2>Минусы</h2>
                        <div>{{art.art_note}}</div><br>
                        <div> Реализация на <a :href='sp.sample_part_gitref'>GitHub</a></div>
                    </m-content>
                </div>
            </v-sec>
        </div>
    `,
    props: ['art'],
});