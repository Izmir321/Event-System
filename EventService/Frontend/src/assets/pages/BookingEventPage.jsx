import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'

const BookingEventPage = () => {
  const {navigate} = useNavigate()
  const { id } = useParams()

  const [event, setEvents] = useState({})
  const [formData, setFormData] = useState({
    eventId: id,
    firstName: '',
    lastName: '',
    email: '',
    streetName: '',
    postalCode: '',
    city: '',
    TicketQuantity: 1
  })

  const getEvents = async () => {
    const res = await fetch(`https://eventservice-euchhwdpc9evgcdp.swedencentral-01.azurewebsites.net/api/events/${id}`)

    if (res.ok) {
      const response = await res.json()
      setEvents(response.result)
    }
  }

  const postBooking = async () => {
    const res = await fetch(`https://bookingservice-euchhwdpc9evgcdp.swedencentral-01.azurewebsites.net/api/bookings/`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(formData)
    })

    if (res.ok) {
      console.error('Booking failed!')
    } else {
      console.log('Booking successful!.')
      navigate('/')
    }
  }

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value })
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    await postBooking()
  }

  useEffect(() => {
    getEvents()
  }, [])

  return (
    <div>
      <h1>Book Event - {event.title}</h1>
      <div>
        <form onSubmit={handleSubmit} noValidate>
          <div>
            <label>First Name</label>
            <input type="text" name="firstName" value={formData.firstName} onChange={handleChange} required />
          </div>
          <div>
            <label>Last Name</label>
            <input type="text" name="lastName" value={formData.lastName} onChange={handleChange} required  />
          </div>
          <div>
            <label>Email</label>
            <input type="email" name="email" value={formData.email} onChange={handleChange} required  />
          </div>
          <div>
            <label>Street Name</label>
            <input type="text" name="streetName" value={formData.streetName} onChange={handleChange} required  />
          </div>
          <div>
            <label>Postal Code</label>
            <input type="text" name="postalCode" value={formData.postalCode} onChange={handleChange} required  />
          </div>
          <div>
            <label>City</label>
            <input type="text" name="city" value={formData.city} onChange={handleChange} required  />
          </div>
          <button type="submit">Book</button>
        </form>
      </div>
    </div>
  )
}

export default BookingEventPage
