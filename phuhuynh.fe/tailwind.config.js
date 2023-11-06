// tailwind.config.js
module.exports = {
	content: ["./index.html", "./src/**/*.{vue,js,ts,jsx,tsx}"],
	media: false,
	theme: {
		extend: {
			colors: {
				'main': '#002a5c',
				'blue_1': '#f3f7f9',
				'blue_2': '#1da1f2'
			},
			width: {
				'42px': '42px'
			},
			maxHeight: {
				'780px': '780px',
			},
			height: {
				'800px': '800px',
				'750px': '750px',
				'650px': '650px',
				'100px': '100px',
				'1-7': '1.7rem'
			},
			top: {
				'1': '1px',
			},
			backgroundImage: {
				'login': "url('assets/login-form-background.png')",
				'footer': "url('assets/footer-background.png')",
				'list-dichvu': "url('assets/bg/service-background.png')",
			},
			fontSize: {
				'32px': '32px',
				'25px': '25px',
				'14px': '14px',
				'42px': '42px'
			},
		},
	},
	variants: {
		extend: {
			color: {
				'main': '#2d3e99',
			}
		},
	},
	plugins: [],
}
