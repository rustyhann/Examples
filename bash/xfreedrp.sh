#!/bin/bash

# /d = domain
# /u = user
# /v = machine
# /g = RDP gateway
# /p = password
# zenity - popup to enter a password securely

xfreerdp \
	/f \
	/d:ads \
	/u:aitadmn1 \
	/v:bl-ait-b5qq8y1.ads.iu.edu \
	/g:gateway.ait.indiana.edu \
	/p:$(zenity \
		--entry \
		--title="Domain Password" \
		--text="Enter your password:" \
		--hide-text)
