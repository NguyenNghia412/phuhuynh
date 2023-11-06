<template>
    <div class="px-6 h-full text-gray-800">
        <div class="flex xl:justify-center lg:justify-between justify-center items-center h-full g-6">
            <div class="hidden md:block grow-0 shrink-1 md:shrink-0 basis-auto xl:w-3/12 lg:w-4/12 md:w-5/12 mb-12 md:mb-0">
                <img src="https://cdni.iconscout.com/illustration/premium/thumb/parents-with-childrens-6005815-4989879.png" class="w-full" alt="Sample image" />
            </div>
            <div class="xl:ml-20 xl:w-5/12 lg:w-7/12 md:w-6/12 w-full mb-12 md:mb-0">
                <Form @submit="onLogin">
                    <!-- Email input -->
                    <div class="mb-6">
                        <Field name="username" class="
                                form-control
                                block
                                w-full
                                px-4
                                py-2
                                text-xl
                                font-normal
                                text-gray-700
                                bg-white bg-clip-padding
                                border border-solid border-gray-300
                                rounded
                                transition
                                ease-in-out
                                m-0
                                focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none
                            "
                            id="exampleFormControlInput2"
                            placeholder="Tài khoản" />
                        <ErrorMessage name="username" />
                    </div>

                    <!-- Password input -->
                    <div class="mb-6">
                        <Field name="password"
                            type="password"
                            class="
                                form-control
                                block
                                w-full
                                px-4
                                py-2
                                text-xl
                                font-normal
                                text-gray-700
                                bg-white bg-clip-padding
                                border border-solid border-gray-300
                                rounded
                                transition
                                ease-in-out
                                m-0
                                focus:text-gray-700 focus:bg-white focus:border-blue-600 focus:outline-none
                            "
                            id="exampleFormControlInput2"
                            placeholder="Mật khẩu"
                        />
                        <ErrorMessage name="password" />
                    </div>

                    <div class="flex justify-between items-center mb-6">
                        <div class="form-group form-check">
                            <input
                                type="checkbox"
                                class="
                                    form-check-input
                                    appearance-none
                                    h-4
                                    w-4
                                    border border-gray-300
                                    rounded-sm
                                    bg-white
                                    checked:bg-blue-600 checked:border-blue-600
                                    focus:outline-none
                                    transition
                                    duration-200
                                    mt-1
                                    align-top
                                    bg-no-repeat bg-center bg-contain
                                    float-left
                                    mr-2
                                    cursor-pointer
                                "
                                id="exampleCheck2"
                            />
                            <label class="form-check-label inline-block text-gray-800" for="exampleCheck2">Remember me</label>
                        </div>
                        <a href="#!" class="text-gray-800">Quên mật khẩu?</a>
                    </div>

                    <div class="text-center lg:text-left">
                        <button
                            type="submit"
                            class="
                                w-full
                                md:w-auto
                                inline-block
                                px-7
                                py-3
                                bg-blue-600
                                text-white
                                font-medium
                                text-sm
                                leading-snug
                                uppercase
                                rounded
                                shadow-md
                                hover:bg-blue-700 hover:shadow-lg
                                focus:bg-blue-700 focus:shadow-lg focus:outline-none focus:ring-0
                                active:bg-blue-800 active:shadow-lg
                                transition
                                duration-150
                                ease-in-out
                            "
                        >
                            Login
                        </button>
                        <!-- <p class="text-sm font-semibold mt-2 pt-1 mb-0">
                            Don't have an account?
                            <a href="#!" class="text-red-600 hover:text-red-700 focus:text-red-700 transition duration-200 ease-in-out">Register</a>
                        </p> -->
                    </div>
                </Form>
            </div>
        </div>
    </div>
</template>

<script>
import { mapMutations } from 'vuex'
import { USER_MUTATIONS } from '../store/types/user.types'
import { useToast } from 'vue-toastification'
import { apiLogin } from '../api/api.auth'
import { getMyPermissions } from '../api/api.dichvu'
import { Form, Field, ErrorMessage } from 'vee-validate'
import * as yup from 'yup'

export default {
    setup() {
        // Get toast interface
        const toast = useToast()
        const validateSchema = yup.object({
            username: yup.string().required('Tên đăng nhập không được bỏ trống').trim(),
            password: yup.string().required('Mật khẩu không được bỏ trống').trim(),
        })
        // Make it available inside methods
        return { toast, validateSchema }
    },
    components: { Form, Field, ErrorMessage },
    methods: {
        ...mapMutations([USER_MUTATIONS.LOGIN]),
        onLogin(data) {
            apiLogin(data)
                .then((res) => {
                    if (res.status === 200) {
                        this[USER_MUTATIONS.LOGIN]({
                            accessToken: res.data.access_token,
                            refreshToken: res.data.refresh_token,
                        })

                        this.toast.success('Đăng nhập thành công')
                        this.$router.push('/home');
                    } else {
                        this.toast.success('Có sự cố xảy ra khi đăng nhập')
                    }
                })
                .catch((err) => {
                    const msg = err?.response?.data?.message || 'Có sự cố xảy ra khi đăng nhập'
                    this.toast.error(msg)
                })
        },
    },
}
</script>
