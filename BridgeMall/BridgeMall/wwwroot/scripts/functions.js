function debounce(func, delay) {
	let timer = null;

	return function wrapper(...args) {
		if (timer) {
			clearTimeout(timer);
		}
		timer = setTimeout(() => func(...args), delay);
	};
}

function IsInputValid(inputElementId) {
	const inputElement = document.getElementById(inputElementId);
	return inputElement.validity.valid && inputElement.value != '';
}

function IsFormValid(inputElementIdList) {
	try {
		let val = true;
		inputElementIdList.forEach(id => {
			val = val && IsInputValid(id)
		});
		return val;
	}
	catch{
		return false;
	}
}

function CheckFormValidity(dotNetHelper, inputElementIdList) {
	inputElementIdList.forEach(id => {
		var inputElement = document.getElementById(id).addEventListener('keyup', () => {
			function misc(dotNetHelper) {
				dotNetHelper.invokeMethodAsync("ChangeButtonState", IsFormValid(inputElementIdList))
			}
			let debounced = debounce(misc, 600);
			debounced(dotNetHelper)
		});
	});
}

function ShowElement(query) {
	let element = document.querySelector(query)
	element.classList.remove('hidden')
}


function HideElement(query) {
	try {
		let element = document.querySelector(query)
		element.classList.add('hidden')
	} catch (e) {

	}
}

const KeyExists = (key) => {
	return (localStorage.hasOwnProperty(key))
}

const encodeText = (text) => {
	let encoder = new TextEncoder()
	return encoder.encode(text).toString()
}

const decodeText = (text) => {
	let decoder = new TextDecoder()
	return decoder.decode(Uint8Array.from(text.split(",")));
}

function EncodeText(text) {
	return encodeText(text)
}

function DecodeText(text) {
	return decodeText(text)
}

function decryptToken(token) {
	let [, infoSection] = token.split('.')
	return JSON.parse(atob(infoSection))
}

function getAccountIdFromToken(token) {
	return decryptToken(token).AccountId
}

function getEmailFromToken(token) {
	return decryptToken(token).Email
}

function getPasswordFromToken(token) {
	return decryptToken(token).Password
}

function getPhoneNumberFromToken(token) {
	return decryptToken(token).PhoneNumber
}

function getUserIdFromToken(token) {
	return decryptToken(token).UserId
}

function getUserId(userIdKey) {
	if (KeyExists(userIdKey) == true) {
		return decodeText(getKeyValue(userIdKey))
	}
	return null
}

function getUserToken(tokenKey) {
	if (KeyExists(tokenKey) == true) {
		return decodeText(getKeyValue(tokenKey))
	}
	return null
}

function IsMobileDevice() {
	const ua = navigator.userAgent.toLowerCase();
	const isMobile = ua.match(/(iPad)|(iPhone)|(iPod)|(android)|(webOS)/i);
	return !(!isMobile);
}

function GetScreenInfo() {
	return {
		"Width": screen.width,
		"Height": screen.height,
		"InnerWidth": window.innerWidth,
		"InnerHeight": window.innerHeight
	}
}

function GetUserAgent() {
	return navigator.userAgent
}

function previewImage(inputElem, imgElementIds) {
	setInterval(() => {
		const url = URL.createObjectURL(inputElem.files[0]);
		imgElement = document.getElementById(imgElementId);
		imgElement.addEventListener('load', () => URL.revokeObjectURL(url), {
			once:
				true
		});
		imgElement.src = url;
	}, 500)
}

window.setImage = async (imageElementId, imageStream) => {
	const arrayBuffer = await imageStream.arrayBuffer();
	const blob = new Blob([arrayBuffer]);
	const url = URL.createObjectURL(blob);
	const image = document.getElementById(imageElementId);
	/*image.onload = () => {
		URL.revokeObjectURL(url);
	}*/
	imageToBase64Async(blob).then((result) => {
		image.src = result
	})
}

function imageToBase64Async(img) {
	return new Promise((resolve, _) => {
		let reader = new FileReader()
		reader.onload = function () {
			resolve(reader.result)
		}
		reader.error = function (error) {
			console.log('Error: ', error)
			popUpBox('error', error)
		}
		reader.readAsDataURL(img)
	})
}

function blobToBase64Ansync(blob) {
	return new Promise((resolve, _) => {
		const reader = new FileReader();
		reader.onloadend = () => resolve(reader.result);
		reader.readAsDataURL(blob);
	});
}

// For home slides
let myslide = null, dot = null, counter = 1;
function startSlides() {
	myslide = document.querySelectorAll('.myslide')
	dot = document.querySelectorAll('.dot');

	slidefun(counter);

	let timer = setInterval(autoSlide, 8000);


	let dots = document.querySelectorAll('.dot')
	dots.forEach((dot) => {
		dot.addEventListener('click', (e) => {
			currentSlide(parseInt(e.target.getAttribute('data-slide-number')))
		})
	})
	function autoSlide() {
		counter += 1;
		slidefun(counter);
		resetTimer();
	}
	function plusSlides(n) {
		counter += n;
		slidefun(counter);
		resetTimer();
	}
	function currentSlide(n) {
		counter = n;
		slidefun(counter);
		resetTimer();
	}
	function resetTimer() {
		clearInterval(timer);
		timer = setInterval(autoSlide, 8000);
	}

	function slidefun(n) {

		let i;
		for (i = 0; i < myslide.length; i++) {
			myslide[i].style.display = "none";
		}
		for (i = 0; i < dot.length; i++) {
			dot[i].className = dot[i].className.replace(' active', '');
		}
		if (n > myslide.length) {
			counter = 1;
		}
		if (n < 1) {
			counter = myslide.length;
		}
		myslide[counter - 1].style.display = "block";
		dot[counter - 1].className += " active";
	}

	document.getElementById('slidePrev').addEventListener('click', (e) => {
		plusSlides(-1)
	})
	document.getElementById('slideNext').addEventListener('click', (e) => {
		plusSlides(1)
	})
}

function initObjectCardSlide(baseSldieClassName, slideCount, slideCountId) {

	let currentSlide = 0;
	const slides = document.querySelectorAll(`.${baseSldieClassName}`);
	const slideElement = document.querySelector(`#${slideCountId}`);
	function showSlide(index) {
		slides.forEach((slide, i) => {
			let percentage = 100 * (i - index);
			slide.style.transform = `translateX(${percentage}%)`;
			slideElement.innerHTML = `${currentSlide + 1}/${slideCount}`;
		});
	}

	function nextSlide() {
		currentSlide = (currentSlide + 1) % slides.length;
		showSlide(currentSlide);
	}

	function prevSlide() {
		currentSlide = (currentSlide - 1 + slides.length) % slides.length;
		showSlide(currentSlide);
	}

	//console.log("slidePrevious", slides)
	try {
		let slidePrevious = document.getElementById(`${baseSldieClassName}_prev`);
		let slideNext = document.getElementById(`${baseSldieClassName}_next`);
		slidePrevious.addEventListener("click", prevSlide);
		slideNext.addEventListener("click", nextSlide);
	} catch (e) {
		console.log("slidePrevious", e)
	}


	showSlide(currentSlide);
	//setInterval(nextSlide, 5000)
}